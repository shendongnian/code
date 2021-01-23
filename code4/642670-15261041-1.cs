    public interface IConnection : IDisposable 
    {
       string DoSomething(string input); 
       // implement IDisposable
    }
    
    public interface IConnectionFactory 
    {
       IConnection CreateConnection(); 
    } 
    
    public class DerpConnection : IConnection 
    {
        // implementation
    } 
    
    public class DerpConnectionFactory : IConnectionFactory 
    {
      // We only return DerpConnections from this factory.  
    
      IConnection CreateConnection() { return new DerpConnection(); } 
    }
    
    public class BarManager 
    { 
       private IConnectionFactory _connectionFactory; 
       public BarManager(IConnectionFactory connectionFactory)
       {   
          _connectionFactory = connectionFactory;
       } 
    
       public Manage()
       {
          using(var connection = _connectionFactory.CreateConnection()) 
          { 
            // do something here. 
          } 
       }
    }
