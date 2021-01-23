    bool Grid1Fired = false;
    bool Grid2Fired = false;
    
    void handler_Grid1(..)
    {
        if(Grid1Fired == false && Grid2Fired == false)
    	{
    		Grid1Fired = true;
    		SortGrids();
    	}
    }
    void handler_Grid2(..)
    {
        if(Grid1Fired == false && Grid2Fired == false)
    	{
    		Grid2Fired = true;
    		SortGrids();
    	}
    }
    
    void SortGrids()
    {
    	if(Grid1Fired)
    	{
    		// sort grid 2
    	}
    	else if(Grid2Fired)
    	{
    		// sort grid 1
    	}
        Grid1Fired = false;
    	Grid2Fired = false;
    }
