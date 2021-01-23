    SqlConnection conn = null;
    
    try
    {
        conn = new SqlConnection("");
    }
    catch ...
    {
    
    }
    finally
    {
        if (conn != null)
            conn.Dispose();
    }
