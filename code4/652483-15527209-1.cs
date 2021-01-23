    try
    {
        SqlConnection connection1 = new SqlConnection(ConnectionString1);
    }
    catch (Exception e)
    {
    }
    finally
    {
        if (connection1 != null)
            ((IDisposable)connection1).Dispose();
    }
