    public class RepositoryBase
    {
        private string connectionString;
        public static string RepositoryBase()
        {
            connectionString= ConfigurationManager.ConnectionStrings["MyTeamScoresDB"].ConnectionString;
        }
    
        protected string ConnectionString
        {
           get { return connectionString;}
        }
      ....
    }
    
    public class OrganizationRepository : RepositoryBase
    {
        // Can use the ConnectionString property of the base class
    }
