	public partial interface IMonth {
		int Number {
			get;
		}
	}
	public partial class February: IMonth {
		public int Number {
			get {
				return 2;
			}
		}
	}
	public static partial class Extensions {
		public static DateTime OfMonth<T>(this int day, int year) 
				where T: IMonth, new() {
			var month=new T();
			var daysInMonth=DateTime.DaysInMonth(year, month.Number);
			if(1>day||day>daysInMonth)
				throw new ArgumentException();
			return new DateTime(year, month.Number, day);
		}
	}
