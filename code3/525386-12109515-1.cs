	class Program
	{
		static void Main(string[] args)
		{
			var period = new TimePeriod(
						DateTime.Now.AddDays(-2),
						DateTime.Now.AddDays(1));
			var date = DateTime.Now;
			var contains = period.Contains(date); // true
			var isBefore = period.IsBefore(date); // false
			var isAfter = period.IsAfter(date);   // false
			
			date = DateTime.Now.AddDays(-10);
			contains = period.Contains(date); // false
			isBefore = period.IsBefore(date); // true
			isAfter = period.IsAfter(date);   // false
			date = DateTime.Now.AddDays(10);
			contains = period.Contains(date); // false
			isBefore = period.IsBefore(date); // false
			isAfter = period.IsAfter(date);   // true
		}
	}
