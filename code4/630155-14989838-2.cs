    class MonitorJob : IJob
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
    
    			Thread.Sleep(TimeSpan.FromSeconds(8));
    
    			Application.Current.Dispatcher.Invoke((Action)(() =>
    			{
    				win.Hide();                   
    			}));
    		}
    	}
    }
