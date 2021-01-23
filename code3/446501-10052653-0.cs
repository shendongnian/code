    public void TestInvokeDelegate()
    {
    	InvokeDelegate( new TestDelegate(ShowMessage), "hello" );
    }
    
    public void InvokeDelegate(TestDelegate del, string message)
    {
    	del(message);
    }
    
    public delegate void TestDelegate(string message);
    
    public void ShowMessage(string message)
    {
    	Debug.WriteLine(message);
    }
