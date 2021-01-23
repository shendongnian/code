    public class MyDbContext : DbContext
    {
        public MyDbContext ()
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
        ...
    }
