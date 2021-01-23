    public class Priority 
    {
        public enum Types
        {
	        High,
	        Medium,
	        Low
        }
        public Types Type { get; private set; }
        public string Name { get { return this.Type.ToString(); } } // ToString() with no arguments is not deprecated
        public string Description { get; private set; }
        public static High = new Priority{ Type = Types.High, Description = "..."};
        public static Medium = new Priority{ Type = Types.Medium, Description = "..."};
        public static Low = new Priority{ Type = Types.Low, Description = "..."};
        public static IEnumerable<Priority> All = new[]{High, Medium, Low};
        public static Priority For(Types priorityType)
        {
            return All.Single(x => x.Type == priorityType);
        }
    }
