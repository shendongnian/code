    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["test"].ConnectionString))
    using (SqlCommand comm = new SqlCommand("testTimeout", conn))
    {
        // next line is where the Connection Timeout will take 
        // effect if the connection cannot be opened in time
        conn.Open();
        comm.CommandType = System.Data.CommandType.StoredProcedure;
        comm.CommandTimeout = 60;
        // next line is where the Command Timeout takes effect
        // if the operation takes a long time to complete
        comm.ExecuteNonQuery();
    }
