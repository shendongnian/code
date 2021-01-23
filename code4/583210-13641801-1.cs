    public class myClass : myInheritage, IStatistics
    {
        private static myClass _instance;
        public static myClass  Instance
        {
            get { return _instance ?? (_instance = new myClass()); }
        }
        public static void Reset()
        {
            _instance = null;
        }
        
        // You would also inherit from IStatistics in your other classes.
        public void ImposeStatistics()
        {
            // Do stuff.
        }
    }
    
