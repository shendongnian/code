    public class ReportService
    	{
    		public event EventHandler NotifyReportGenerated;
    
    		public Task CreateReportAsync()
    		{
    			return Task.Factory.StartNew(() =>
    				{
    					GenrateActualReport();
    				}).
    			ContinueWith(task =>
    				{
    					if (NotifyReportGenerated != null)
    						NotifyReportGenerated(this, new EventArgs());
    				},
    			TaskScheduler.FromCurrentSynchronizationContext());
    		}
    
    		private void GenrateActualReport()
    		{
    			var a = Task.Delay(10000);
    			Task.WaitAll(a);
    		}
    	}
