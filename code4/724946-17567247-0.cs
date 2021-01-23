    ReadSensor(addr, DoSomethingWithResult);
    public void DoSomethingWithResult(string result)
    {
    	Console.WriteLine (result);
    }
    
    public partial class readSens : UserControl
    {
    	private readonly Action<string> _responseCallback;
    	
    	public void ReadSensor(byte addr, Action<string> responseCallback)
    	{	
    		_responseCallback = responseCallback;
    		
    		// initiate timer
    	}
    	
    	private void OnTimedEvent(object source, ElapsedEventArgs e)
    	{
    		string response = getResponse();
    		
    		_responseCallback(response);
    	}
    }
