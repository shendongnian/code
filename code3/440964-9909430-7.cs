    SqlConnection cn = new SqlConnection(GetDBConnectionString());
    try
    {
        //code
    }
    finally
    {
        if (cn != null)
           ((IDisposable)cn).Dispose();
    }
