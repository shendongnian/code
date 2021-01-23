    public class Something
    	{
    		public int ID;
    		public string Name;
    		public DateTime Date;
    		public string HumanReadableDate { get { return Date.ToLongDateString(); } }
    	}
