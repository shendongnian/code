    try
    {
    	GlobalNamedLock gl = new GlobalNamedLock("MyLockName");
    
    	try
    	{
    		if (gl.enterCRITICAL_SECTION())
    		{
    			//Use the global resource now
    		}
    	}
    	finally
    	{
    		gl.leaveCRITICAL_SECTION();
    	}
    }
    catch (Exception ex)
    {
    	//Failed -- log it
    }
