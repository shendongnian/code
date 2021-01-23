    public static class ConnectionHandler
    {
       static SqlCeConnection myGlobalConnection;
    
       public static SqlCeConnection GetConnection()
       {
          if( myGlobalConnection == null )
             myGlobalConnection = new SqlCeConnection();
    
          return myGlobalConnection;
       }
    
       public static bool SqlConnect()
       {
          GetConnection();   // just to ensure object is created
    
          if( myGlobalConnection.State != System.Data.ConnectionState.Open)
          {
             try
             {
                myGlobalConnection.ConnectionString = @"Data Source=\MyFolder\MyDatabase.sdf";
                myGlobalConnection.Open();
             }
             catch( Exception ex)
             {
                // optionally messagebox, or preserve the connection error to the user
             }
          }
    
          if( myGlobalConnection.State != System.Data.ConnectionState.Open )
             MessageBox.Show( "notify user");
    
          // return if it IS successful at opening the connection (or was already open)
          return myGlobalConnection.State == System.Data.ConnectionState.Open;
       }
    
       public static void SqlDisconnect()
       {
          if (myGlobalConnection!= null)
          {
             if (myGlobalConnection.State == ConnectionState.Open)
                myGlobalConnection.Close();
    
             // In case some "other" state, always try to force CLOSE
             // such as Connecting, Broken, Fetching, etc...
             try
             { myGlobalConnection.Close(); }
             catch
             { // notify user if issue}
          }
       }
    }
