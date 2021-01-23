    public class Singleton
    {
        private static readonly Singleton SingleInstance;
        
        static Singleton()
        {
            /* initializes the static field the first time anything is accessed on 
               the Singleton class .NET ensures threadsafety on static initializers. */
            SingleInstance = new Singleton(Datetime.Now);
        }
        public static Singleton Instance
        {
            get
            {
                return SingleInstance;
            }
        }
        /// <summary>
        /// Keep the constructure private on Singleton objects to avoid other instances being contructed
        /// </summary>
        private Singleton(DateTime value)
        {
            Value = value;
        }
        public DateTime Value { get; private set; }
    }
