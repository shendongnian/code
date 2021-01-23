    public static class LocatorInitializationHandler
    {
        public static void Initialize()
        {
            // if you want to use your initializer
            Database.SetInitializer(new CreateInitializer()); 
            
            using (var db = new LocatorContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
