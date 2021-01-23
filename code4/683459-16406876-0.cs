    try
    {
        // call EF SP method here...
    }
    catch(SqlException se)
    {
        Debug.WriteLine(se.Message);
    }
    catch(Exception e)
    {
        // all non-DB errors will be seen here...
    }
