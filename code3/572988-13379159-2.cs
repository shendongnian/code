     public class DbAccess : IDisposable
    {
        public DbAccess()
        {
            var cnx=ConfigurationManager.ConnectionStrings[0];
            if (cnx==null) throw new InvalidOperationException("I need a connection!!!");
            
            Init(cnx.ConnectionString,ProviderFactory.GetProviderByName(cnx.ProviderName));
        }
        public DbAccess(string connectionStringName)
        {
            var cnx = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (cnx == null) throw new InvalidOperationException("I need a connection!!!");
            Init(cnx.ConnectionString, ProviderFactory.GetProviderByName(cnx.ProviderName));
        }
        public DbAccess(string cnxString,string provider)
        {
            Init(cnxString,ProviderFactory.GetProviderByName(provider));
        }
        public DbAccess(string cnxString,DBType provider)
        {
          Init(cnxString,ProviderFactory.GetProvider(provider));
        }
        public DbAccess(string cnxString,IHaveDbProvider provider)
        {
            Init(cnxString, provider);
        } //other stuff
       }
