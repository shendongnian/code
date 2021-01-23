    public class MyDatabaseInitializer : DropDatabaseIfModelChanges<MyDatabaseContext>()
    {
        public MyDatabaseInitializer() : base ()
        {
            var context = new MyDatabaseContext();
            
            Seed(context);
    
            base.InitializeDatabase(context);
    
            // any other things I need to do here with the database
        }
    
        public override Seed(UXContext context)
        {
            // do my seed data here
        }
    } 
