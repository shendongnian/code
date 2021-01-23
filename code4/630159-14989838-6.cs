    class HideJob: IJob
    {
    	public void Execute(IJobExecutionContext context)
    	{
    		Window win = context.JobDetail.JobDataMap.Get("window") as Window;          
    		if (win != null && Application.Current != null)
    		{               
    			Application.Current.Dispatcher.Invoke((Action)(() =>
    			{
    				win.Hide();
    			}));
    		}            
    	}
    }
