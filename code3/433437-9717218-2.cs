    try
    {
        OpenConnectionToDatabase();
        // something likely to fail
    }
    catch (Exception ex)
    {
        Log(ex);
        throw;  
        // throw ex; // also works but behaves differently
    }
    // Not specifying an exception parameter also works, but you don't get exception details.
    //catch (Exception)
    //{
    //    Log("Something went wrong);
    //    throw;
    //}
    finally
    {
        CloseConnectionToDatabase();
    }
