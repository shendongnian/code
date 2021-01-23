    class MonitorJob : IJob
    {
    	public void Execute(IJobExecutionContext context)
    	{
    		MonitorHelper.TurnOff();
    		Thread.Sleep(TimeSpan.FromSeconds(2));
    		MonitorHelper.TurnOn();
    	}
    }
