    try
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
        ...
    }
    finally
    {
        if (con != null) con.Dispose();
        if (cmd != null) cmd...
    }
