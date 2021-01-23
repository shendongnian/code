    public static class MyInitializationHandler
    {
        public static void Initialize()
        {
            using (var db = new MyContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
