    public class Something
    	{
    		public int ID;
    		public string Name;
    		public DateTime Date;
    		#if DEBUG
    		public string HumanReadableDate { get { return Date.ToLongDateString(); } }
    		#endif
    	}
