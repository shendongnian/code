    public class Stage : Enumeration
    {
        public TimeSpan TimeSpan { get; private set; }
        public static readonly Stage One
            = new Stage (1, "Stage one", new TimeSpan(5));
        public static readonly Stage Two
            = new Stage (2, "Stage two", new TimeSpan(10));
        public static readonly Stage Three
            = new Stage (3, "Stage three", new TimeSpan(15));
    
        private EmployeeType() { }
        private EmployeeType(int value, string displayName, TimeSpan span) : base(value, displayName) 
        { 
            TimeSpan = span;
        }
    }
