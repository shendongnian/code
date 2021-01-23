    finally
    {
       sqlconn.Close();
       SqlConnection.ClearAllPool();  // this statement clears pool
       sqlConn.Dispose(); 
    }
