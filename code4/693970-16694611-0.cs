    class DataHandler
    {
        private DataHandler() {}
        public GetX() { ... }
    
        private static DataHandler instance = null;
    
        public static Instance
        {
            get
            {
                if (instance == null)
                {
                    return (instance = new DataHandler());
                }
            }
        }
    }
