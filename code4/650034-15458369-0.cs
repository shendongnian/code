    try
    {
        //Do work
    }
    catch (Exception ex)
    {
        var sqlEx = ex as SqlException;
        if (sqlEx != null && sqlEx.Number == -2)
        {
            debugLogSQLTimeout(ex);
        }
        else
        {
            debugLogGeneralException(ex);
        }
    }
