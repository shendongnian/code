    public interface IDbConnectionFactory
    {
      public IDbConnection GetConnection();
    }
    
    public class OracleConnectionFactory : IDbConnectionFactory
    {
      public IDbConnection GetConnection()
      {
        return new OracleConnection();
      }
    }
    
    public class MyAwesomeDataAccess
    {
      private IDbConnectionFactory dbConnectionFactory;
    
      public void MyAwesomeDataAccess(IDbConnectionFactory() dbConnectionFactory)
      {
        this.dbConnectionFactory = dbConnectionFactory;
      }
    
      public SomeData SomeMethod()
      {
        var connection = dbConnectionFactory.GetConnection();
        // do stuff with connection...
      }
    }
