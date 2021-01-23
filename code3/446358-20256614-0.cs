    public class InternalDateTime
    {
        private static volatile InternalDateTime _instance;
        private static object syncRoot = new Object();
        //threadsafe singleton
        public static InternalDateTime Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new InternalDateTime();
                    }
                }
                return _instance;
            }
        }
        private Stopwatch sw;
        private DateTime dtAppStart;
        private InternalDateTime()
        {
            dtAppStart = DateTime.Now;
            sw = new Stopwatch();
            sw.Start();
        }
        public static DateTime Now { get { return InternalDateTime.Instance.DateTimeNow; } }
        public DateTime DateTimeNow
        {
            get
            {
                 return new DateTime(dtAppStart.Ticks).AddMilliseconds(sw.ElapsedMilliseconds);
            }
        }
    }
