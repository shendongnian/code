    public class ConcurrencyThrottle : IConcurrencyThrottle
    {
        private int Max { get; set;}
        private static object _lock = new object();
        private static object _concurrencyLock = new object();
        public static MaxRegister Register { get; set; }
        private static volatile _Default;
        private ConcurrencyThrottle()
        {
            Register = new MaxRegister
            {
                CurrentValue = 0,
                MaxValue = 2
            };
        }
        public static ConcurrencyThrottle Default
        {
            get
            {
                lock (_lock)
                {
                    if(_Default == null)
                    {
                        _Default = new ConcurrencyThrottle();
                    }
                    return_Default;
                }
            }
        }
        public void Enter() 
        { 
            lock (_concurrencyLock) 
            { 
                while (Register.CurrentValue == _max) 
                    Monitor.Wait(_concurrencyLock); 
 
                Register.Increment(); 
            } 
        } 
        etc etc
