    public class MyContext : DbContext
    {    
        public MyContext () : base(ContextHelper.CreateConnection("my connection string"), true)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }
    }
