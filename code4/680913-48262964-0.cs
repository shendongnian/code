    public class ActiveDirectoryJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var staffService = new StaffService();
            staffService.Synchronize();
            
            int intervalTime=2;
            ITrigger rsiTrigger = TriggerBuilder.Create()
            .WithIdentity(context.Trigger.Key.Name)
            .StartAt(DateTime.Now.AddHours(intervalTime))
            .WithSimpleSchedule(x => x
            .WithIntervalInHours(intervalTime)
            .RepeatForever())
            .Build();
            context.Scheduler.RescheduleJob(new TriggerKey(context.Trigger.Key.Name, ((AbstractTrigger)context.Trigger).Group), rsiTrigger);
        }
    }
