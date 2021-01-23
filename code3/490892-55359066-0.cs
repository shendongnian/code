    try
    {
    
    }
    catch(SQLiteException ex)
    {
        SQLiteErrorCode sqlLiteError= (SQLiteErrorCode)ex.ErrorCode;
    
        //Do whatever logic necessary based of the error type
    }
