    SqlConnection con = new SqlConnection(connectionString)
    try
    {
       con.Open(); <-- open method
    
       string queryString = "select * from db";
       SqlCommand cmd = new SqlCommand(queryString, con);
       SqlDataReader reader = cmd.ExecuteReader();
       reader.Read();
    }
    finally
    {
        if (con!= null)
            ((IDisposable)con).Dispose();
    }
