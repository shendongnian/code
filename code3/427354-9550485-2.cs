    static void Main(string[] args)
    {
         Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<YourContext>());
         //or
         Database.SetInitializer(
                new DropCreateDatabaseAlways<YourContext>());
         //your code
    }
