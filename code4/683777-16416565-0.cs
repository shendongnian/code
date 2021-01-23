    SqlConnection conn;
    try
    {
        conn = new SqlConnection(_dbconnstr));
    }
    catch
    {
        //exceptions are bubbled
        throw;
    }
    finally
    {
        //Dispose is always called
        conn.Dispose();
    }
    
