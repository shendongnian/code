    try
    {
        MyData.ConExec(sSQL);
    }
    catch (OleDbException ex)
    {
    	// handle excpetion here...
    	if (ex.ErrorCode == -2147217873)
    	{
    	 
    	}
    }
    catch (Exception e)
    {
    	// if other exception will occur
    }
