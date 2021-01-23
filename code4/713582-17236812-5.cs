    public static class MyInitializationHandler
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateInitializer()); //if u want to use your initializer
            using (var db = new MyContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
