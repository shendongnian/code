    int count =0;
    const int MAX_CALLS = 5;
    
    public void RunService()
    {
    	//do service stuff
    }
    
    public void CallBackMethod(int serviceResult)
    {
    	if (count++ < MAX_CALLS)
    		RunService ();
    }
    public static void Main (string[] args)
    {
    	RunService ();
    }
