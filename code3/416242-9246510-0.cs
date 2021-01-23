    public class MyClass
    {
        private static MyClass sInstance
        private static DateTime sInstanceLastUpdated = DateTime.MinValue;
        public static MyClass Instance
        {
            get
            {
                if(sInstance == null || DateTime.Now.Subtract(sInstanceLastUpdated).TotalMinutes > 30)
                {
                    sInstance = new MyClass();
                    // initialize.
                }
                return sInstance;
            }
        }
    }
