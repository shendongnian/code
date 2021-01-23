    public class WinService : ServiceBase
    {
    	protected override void OnStart(string[] args)
    	{
    		...
    	}
    
    	protected override void OnStop()
    	{
    		...
    	}
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
                ...
        }
    }
