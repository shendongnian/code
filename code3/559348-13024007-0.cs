    using (SqlConnection conn = new SqlConnection(connectionString))
    {
      conn.Open();
      ///Use the connection ....
      ///.
      ///.
      ///.
      /// The connection will be closed and disposed automatically before the end of (using) block;
    }
