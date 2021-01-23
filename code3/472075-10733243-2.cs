    public class MyComplexInitializer : IDatabaseInitializer<MyContext>
    { 
        public void InitializeDatabase(MyContext context)
        {
            if (context.Database.Exists() && 
               !context.Database.CompatibleWithModel(false))
            {
                 //do something bofore delete
                 context.Database.Delete();
                 context.Database.Create();
                 //add some data to context
                 context.SaveChanges();                 
            }
        }
    }
