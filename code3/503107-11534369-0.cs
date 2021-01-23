    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
    
        protected override void Seed(MyDbContext context)
        {
            context.AddSomeInitialData();
            context.SaveChanges();        
        }
    
    }
