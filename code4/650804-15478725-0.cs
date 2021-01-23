    class Logmanager : IDisposable
    {
    	public Logmanager()
    	{
    		this.Log("Start");
    	}
    
    	private void Log(string message)
    	{
    		// some logging implementation
    	}
    	public void Dispose()
    	{
    		this.Log("Finish");
    	}
    }
