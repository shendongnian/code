    class MyClass1
    {
    	public MyClass1()
    	{
    		var c2 = new MyClass2();
    		
    		c2.ActionwebServiceCalled += MyCallBack; //register for the event
    		c2.CallWebService();
    	}
    	
    	public void MyCallBack(object sender, DownloadStringCompletedEventArgs e)
    	{
    		Console.Write("Function returned!");
    	}
    }
    
    class MyClass2
    {
    	public event DownloadStringCompletedEventHandler ActionwebServiceCalled;
    	
    	public void CallWebService()
    	{
    		DownloadStringCompletedEventArgs e = null;
    		
    		//Calls web service and does some other operations...
    		
    		var handler = ActionwebServiceCalled;
    		if (handler != null)
    			handler(this, e);
    	}
    }
