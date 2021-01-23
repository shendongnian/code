    private async Task programCore()
    {
    	int n = 1000;
    	for (int i = 0; i < n; )
    	{
    		await FirstThing(); 
    		await SecondThing();
    		await ThirdThing();
       }
    }
    
    private async Task FirstThing()
    {
    	// Do something here
    }
    
    private async Task SecondThing()
    {
    	// Do something here
    }
    
    private async Task ThirdThing()
    {
    	// Do something here
    }
