    public class Singleton
    {
        private static readonly Lazy<Singleton> LazyInstance = new Lazy<Singleton>(() => new Singleton(DateTime.Now));
        
        public static Singleton Instance
        {
            get
            {
                return LazyInstance.Value;
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
