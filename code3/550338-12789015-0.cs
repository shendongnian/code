    public class MyDatabase : DbContext
    {
        public MyDatabase ()
            : base(ContextHelper.CreateConnection("Connection string"), true)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }
    }
