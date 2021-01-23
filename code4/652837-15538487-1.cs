    SqlConnection cn = null;
    try
    {
        cn = new SqlConnection(strConnectString);
        // Stuff
    }
    finally
    {
        if (cn != null) cn.Dispose();
    }
