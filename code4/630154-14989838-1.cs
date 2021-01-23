    public partial class MainWindow : Window
    {
    	public MainWindow()
    	{
    		InitializeComponent();
    		Init();
    	}
    
    	private void Init()
    	{
    		ISchedulerFactory schedFact = new StdSchedulerFactory();
    		IScheduler sched = schedFact.GetScheduler();
    
    		IDictionary<string, object> map = new Dictionary<string, object>();
    		map.Add("window", this);
    
    		IJobDetail job = JobBuilder.Create<MonitorJob>()
    		 .WithIdentity("monitorJob", "group")             
    		 .UsingJobData(new JobDataMap(map))
    		 .Build();
    
    		ITrigger trigger = TriggerBuilder.Create()
    		  .WithIdentity("monitorTrigger", "group")
    		  .StartNow()
    		  .WithSimpleSchedule(x => x.WithIntervalInMinutes(1).RepeatForever())
    		  .Build();
    
    		sched.ScheduleJob(job, trigger);
    		sched.Start();
    	}
    }
