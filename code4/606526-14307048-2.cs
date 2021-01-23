    public void Execute()
    {
    	Func<int, int> func = webService.GetResponce;
    
    	var countdownEvent = new CountdownEvent(5);
    	var res = new List<int>();
    	for (int i = 0; i < 5; ++i)
    	{
    		func.BeginInvoke(1, ar =>
    			            {
    							var asyncDelegate = (Func<int, int>)((AsyncResult)ar).AsyncDelegate;
    				            int ii = asyncDelegate.EndInvoke(ar);
    							res.Add(ii);
    							((CountdownEvent)((AsyncResult)ar).AsyncState).Signal();
    						}, countdownEvent);
    	}
    	countdownEvent.Wait();
    	Console.WriteLine(res.Count);
    }
