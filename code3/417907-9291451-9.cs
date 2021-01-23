    SqlConnection conn;
    
    try
    {
        conn = new SqlConnection("");
        // Do stuff.
    }
    finally
    {
        if (conn != null)
            conn.Dispose();
    }
