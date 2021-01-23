    class DataAccess
    {
        private static DataContext db = null;
        private DataAccess()
        {
        }
        public static DataContext GetInstance()
        {
            return db ?? (db = new DataContext());
        }
    }
