	public enum Months {
		Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
	}
	public partial class SomeClass {
		public String Jan { get; set; }
		public String Feb { get; set; }
		public String Mar { get; set; }
		public String Apr { get; set; }
		public String May { get; set; }
		public String Jun { get; set; }
		public String Jul { get; set; }
		public String Aug { get; set; }
		public String Sep { get; set; }
		public String Oct { get; set; }
		public String Nov { get; set; }
		public String Dec { get; set; }
		public SomeClass(IConvertible[] array) {
			var count=(
				from Months month in Enum.GetValues(typeof(Months))
				let index=(int)month
				where index<array.Length
				select
					typeof(SomeClass).InvokeMember(
						Enum.GetName(typeof(Months), month),
						BindingFlags.SetProperty|BindingFlags.Instance|BindingFlags.Public,
						default(Binder), this,
						new object[] { Math.Round(array[index].ToDecimal(null), 2).ToString() }
						)
				).Count();
		}
	}
