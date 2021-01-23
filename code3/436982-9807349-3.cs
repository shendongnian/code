    // PseudoCode
    class UnitOfWork : IDisposable
    {
       public UnitOfWork()
       {
          conn = new SqlConnection();
          conn.Open();
       }
    
       public void Dispose()
       {
           conn.Close();
       }
     ....
    }
