    public class DumbJob : IJob
    {
    	public DumbJob() {
    	}
    
    	public void Execute(JobExecutionContext context)
    	{
    		Console.WriteLine("DumbJob is executing.");
    	}
    }
