    class ShowJob: IJob
    {
    	public void Execute(IJobExecutionContext context)
    	{
    		Window win = context.JobDetail.JobDataMap.Get("window") as Window;
    		if (win != null)
    		{
    			Application.Current.Dispatcher.Invoke((Action)(() =>
    			{
    				win.Width = System.Windows.SystemParameters.FullPrimaryScreenWidth;
    				win.Height = System.Windows.SystemParameters.FullPrimaryScreenHeight;
    				win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    				win.WindowStyle = WindowStyle.None;
    				win.Topmost = true;
    				win.WindowState = WindowState.Maximized;
    				win.Show();
    			}));
    
    			IDictionary<string, object> map = new Dictionary<string, object>();
    			map.Add("window", win);
    
    			IJobDetail job = JobBuilder.Create<HideJob>()
    			 .WithIdentity("hideJob", "group")
    			 .UsingJobData(new JobDataMap(map))
    			 .Build();
    
    			ITrigger trigger = TriggerBuilder.Create()
    			  .WithIdentity("hideTrigger", "group")
    			  .StartAt(DateBuilder.FutureDate(5, IntervalUnit.Second))
    			  .Build();
    
    			context.Scheduler.ScheduleJob(job, trigger);
    		}
    	}
    }
