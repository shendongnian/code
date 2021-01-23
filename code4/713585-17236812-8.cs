    public static class LocatorInitializationHandler
    {
        public static void Initialize()
        {
            Database.SetInitializer(new CreateInitializer()); //if u want to use your initializer
            using (var db = new LocatorContext())
            {
                {
                    db.Database.Initialize(true);
                }
            }
        }
    }
