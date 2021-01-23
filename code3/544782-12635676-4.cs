    try 
    {
	}
	catch (SqlException sqlEx) 
    {
       if(sqlEx.ErrorCode == 2601)
       {
          handleDuplicateKeyException();
       }
    }
