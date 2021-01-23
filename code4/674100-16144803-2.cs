    public class MainClass : MainInterface.PluginHostInterface
    {
    	private MainInterface.IMother CSK;
    
    	public void Initialize(MainInterface.IMother mainAppHandler)
    	{
    		CSK = mainAppHandler;
    	}
    
    	public void InitializeEvents(EventProvidingClass eventProvider)
    	{
    		eventProvider.SomeEvent += someEventHandler;
    	}
    
    	private void someEventHandler(object sender, EventArgs e)
    	{
    
    	}
    }
