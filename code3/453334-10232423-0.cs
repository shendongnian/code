    try
    {
       // Tries to affect something
       
       // Then returns
       return;
    }
    catch (Exception ex)
    {
    	// Set default values
    	this.field1 = ....
    }
    finally
    {
       if (gch.IsAllocated)
    	   gch.Free( );
    }
