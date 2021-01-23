	public class TimePeriod
	{
		public DateTime Oldest { get; set; }
		public DateTime Newest { get; set; }
		public TimePeriod(DateTime oldest, DateTime newest)
		{
			Oldest = oldest;
			Newest = newest;
		}
		public bool Contains (DateTime time)
		{
			return Oldest.CompareTo(time) <= 0 && Newest.CompareTo(time) >= 0;
		}
		public bool IsAfter(DateTime time)
		{
			return Newest.CompareTo(time) <= 0;
		}
		public bool IsBefore(DateTime time)
		{
			return Oldest.CompareTo(time) >= 0; 
		}
	}
