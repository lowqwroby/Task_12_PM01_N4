using System;

namespace Variant10
{
	class DataWork
	{
		public DateTime date;

		public DataWork()
		{
			date = new DateTime(2009, 1, 1);
		}

		public DataWork(DateTime date)
		{
			this.date = date;
		}

		public string LastDay(DateTime date)
		{
			DateTime ldate = date.AddDays(-1);
			return ldate.ToShortDateString();
		}

		public string NextDay(DateTime date)
		{
			DateTime ndate = date.AddDays(1);
			return ndate.ToShortDateString();
		}

		public int DaysLeft(DateTime date)
		{
			int dLeft = DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
			return dLeft;
		}

		public string DateValue
		{
			get
			{
				return date.ToShortDateString();
			}
			set
			{
				date = DateTime.Parse(value);
			}
		}

		public bool LeapYear
		{
			get
			{
				if (date.Year % 4 == 0)
					return true;
				else
					return false;
			}
		}

		public string this[int index]
		{
			get
			{
				return date.AddDays(index).ToShortDateString();
			}
		}

		public static bool operator !(DataWork dataWork)
		{
			DateTime d2 = dataWork.date;
			DateTime d1 = dataWork.date.AddDays(1);
			if (d2.Month == d1.Month) return true;
			else return false;
		}

		private bool tf()
		{
			if (date.Day == 1 && date.Month == 1) return true;
			else return false;
		}

		public static bool operator true(DataWork datawork)
		{
			return datawork.tf();
		}
		public static bool operator false(DataWork datawork)
		{
			return !datawork.tf();
		}

		public static bool operator &(DataWork dataWork, DataWork datawork1)
		{
			if (dataWork.date == datawork1.date) return true;
			else return false;
		}

		public static implicit operator string(DataWork data)
		{
			int Year = data.date.Year, Month = data.date.Month, Day = data.date.Day;
			string str = Day + "." + Month + "." + Year;
			return str;
		}

		public static implicit operator DataWork(string data)
		{
			DataWork dataWork = new DataWork(Convert.ToDateTime(data));
			return dataWork;
		}

	}

	class Program
	{
		static void Main()
		{
			try
			{
				Console.WriteLine("1 - Вывод с фиксированнной датой\n" +
								  "2 - Вывод со своей датой");
				int index = Convert.ToInt32(Console.ReadLine());
				switch (index)
				{
					case 1:
						DataWork data = new DataWork();
						Console.WriteLine("Текущая дата: " + data.DateValue);
						Console.WriteLine("Прошлый день текущей даты: " + data.LastDay(data.date));
						Console.WriteLine("Следующий день текущей даты: " + data.NextDay(data.date));
						Console.WriteLine("До конца месяца осталось {0} дней.", data.DaysLeft(data.date));
						if (data.LeapYear)
						{
							Console.WriteLine("Этот год высокосный.");
						}
						else
						{
							Console.WriteLine("Этот год не высокосный.");
						}
						Console.WriteLine("Введите количество дней для отсчета.");
						int i = Convert.ToInt32(Console.ReadLine());
						string str = data[i];
						Console.WriteLine("Дата {0}-того по счету для относительно этой даты: {1}", i, str);
						Console.WriteLine("Не является ли дата последним днем месяца: " + !data);
						if (data) Console.WriteLine("Эта дата является началом года.");
						else Console.WriteLine("Эта дата не является началом года");
						DataWork datac = new DataWork();
						if (data & datac) Console.WriteLine("Поля этих объектов равны");
						else Console.WriteLine("Поля этих объектов не равны");
						DataWork pre1;
						pre1 = (string)data;
						Console.WriteLine("Класс был преобразован из DateTime в string: " + pre1);
						pre1 = (DataWork)data;
						Console.WriteLine("Класс был преобразован из string в DataTime: " + pre1.DateValue);
						break;
					case 2:
						Console.Write("Введите дату через точку: ");
						DateTime setDate = Convert.ToDateTime(Console.ReadLine());
						DataWork data1 = new DataWork(setDate);
						Console.WriteLine("Текущая дата: " + data1.DateValue);
						Console.WriteLine("Прошлый день текущей даты: " + data1.LastDay(data1.date));
						Console.WriteLine("Следующий день текущей даты: " + data1.NextDay(data1.date));
						Console.WriteLine("До конца месяца осталось {0} дней.", data1.DaysLeft(data1.date));
						if (data1.LeapYear)
						{
							Console.WriteLine("Этот год высокосный.");
						}
						else
						{
							Console.WriteLine("Этот год не высокосный.");
						}
						Console.WriteLine("Введите количество дней для отсчета.");
						int i1 = Convert.ToInt32(Console.ReadLine());
						string str1 = data1[i1];
						Console.WriteLine("Дата {0}-того по счету для относительно этой даты: {1}", i1, str1);
						Console.WriteLine("НЕ является ли дата последним днем месяца: " + !data1);
						if (data1) Console.WriteLine("Эта дата является началом года.");
						else Console.WriteLine("Эта дата не является началом года");
						Console.WriteLine("Введите вторую дату: ");
						DateTime set1date = DateTime.Parse(Console.ReadLine());
						DataWork data1c = new DataWork(set1date);
						if (data1 & data1c) Console.WriteLine("Поля этих объектов равны");
						else Console.WriteLine("Поля этих объектов не равны");
						DataWork pre;
						pre = (string)data1;
						Console.WriteLine("Класс был преобразован из DateTime в string: " + pre);
						pre = (DataWork)data1;
						Console.WriteLine("Класс был преобразован из string в DataTime: " + pre.DateValue);
						break;
					default:
						Console.WriteLine("Неверное значение");
						break;
				}
			}
			catch (FormatException)
			{
				Console.WriteLine("Неверный ввод данных");
			}
			catch
			{
				Console.WriteLine("Неизвестная ошибка");
			}
		}
	}
}