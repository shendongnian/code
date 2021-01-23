    class DBConnectionManager
    {
    
    struct Connection
    {
      public string Hostname;
      public string ServerName;
      public string UserName;
      public string Password;
    
      public void Connect()
      {
      }
      
      public void Close()
      {
      } 
    }
    
    private static s_instance;
    public static DBConnectionManager
    {
        get {return instance; }
    }
    
    private List<Connection> m_connections;
    
    public Connection GetConnection(string hostname, string serverName, string userName, string password)
    {
        // if already exist in m_connections
        // return the connection
        // otherwise create new connection and add to m_connections    
    }
    
    public void CloseConnection(string hostname, string serverName, string userName, string password)
    {
        // if find it in m_connections
        // then call Close()
    }
    
    public void CloseAll()
    {
       //
    }
    
    }    
