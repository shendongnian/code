    public void Dummy(ref Connection AConnection, ref TcpClient AClient)
    {
      AConnection = null;
      AClient = null;
    } // void Dummy(...)
    public void Example()
    {
      TcpClient Client = null;
      Connection abc = null;
      while(true)
      {
          // 1. create new Client instance, WITHOUT connection
          Client = new TcpClient()
          //Client = AcceptTcpClient();
          // 2. Create new Connection object that requires Client's reference to it.
          Connection abc = new Connection(Client);
      
          // Add new user to users collection
          Users.Add(abc);
          // uncomment only when debugging
          Dummy(ref abc, ref Client)
      } // while
      // uncomment only when debugging
      Client = null;
      abc = null;
    } // void Example(...)
