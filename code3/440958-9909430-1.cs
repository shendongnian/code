    SqlConnection cn = new SqlConnection(GetDBConnectionString());
    try
    {
        //code
    }
    finally
    {
        cn.Dispose();
    }
