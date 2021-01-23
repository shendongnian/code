    try
    {
    }
    catch(SqlException sqlEx)
    {
        if(sqlEx.ErrorCode == 547)
            throw;
    }
    catch(Exception ex)
    {
        //General error logic
    }
