    public class DailyJob : IJob
    {
        public DailyJob() { }
    
        public void Execute( JobExecutionContext context )
        {
            try {
                DbLayer.ContestManager cm = new DbLayer.ContestManager();
                cm.UpdateAllPhotosInContest();
            } catch( Exception e ) {
                //Handle this please
            }
        }
    
        public static void ScheduleJob( IScheduler sc )
        {
            JobDetail job = new JobDetail("FinishContest", "Daily", typeof(DailyJob));
            sc.ScheduleJob(job, TriggerUtils.MakeDailyTrigger("trigger1", 0, 0));
            sc.Start();
        }
    }
    
    //Global.asax
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
    
                RegisterGlobalFilters(GlobalFilters.Filters);
                RegisterRoutes(RouteTable.Routes);
                
                /* HERE */ DailyJob.ScheduleJob(new StdSchedulerFactory().GetScheduler());
            }
