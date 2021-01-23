    class MySingletonClass 
    {
        private static UserSettings instance = null;
        /// <summary>
        /// Default protected constructor.
        /// </summary>
        protected MySingletonClass()
        {
        }
        /// <summary>
        /// Invoke the singleton instance.
        /// </summary>
        public static MySingletonClass Instance()
        {
            if (instance == null)
                instance = new MySingletonClass();
            return instance;
        }
    }
    
