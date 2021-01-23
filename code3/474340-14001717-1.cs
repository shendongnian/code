    public class QuartzScheduler
    {
       public static void Start()
        {
           ISchedulerFactory schedulerFactory = new StdSchedulerFactory((NameValueCollection)ConfigurationManager.GetSection("quartz"));
           IScheduler scheduler = schedulerFactory.GetScheduler();
           scheduler.Start();
           IJobDetail inviteRequestProcessor = new JobDetailImpl("ProcessInviteRequest", null, typeof(InviteRequestJob));
           IDailyTimeIntervalTrigger trigger = new DailyTimeIntervalTriggerImpl("Invite Request Trigger", Quartz.TimeOfDay.HourMinuteAndSecondOfDay(0, 0, 0), Quartz.TimeOfDay.HourMinuteAndSecondOfDay(23, 23, 59), Quartz.IntervalUnit.Second, 1);
           scheduler.ScheduleJob(inviteRequestProcessor, trigger);
         }
      }
      public class InviteRequestJob : IJob
      {
         public void Execute(IJobExecutionContext context)
         {
            RequestInvite.ProcessInviteRequests();
         }
      }
 
