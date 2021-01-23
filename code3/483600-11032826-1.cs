    public static IScheduler Scheduler { get; private set; }
    private void StartScheduler()
    {
        Scheduler = new StdSchedulerFactory().GetScheduler();
        Scheduler.Start();
        var jobDetail = JobBuilder
            .Create()
            .OfType(typeof(DBCleanUpJob))
            .WithIdentity(new JobKey("test", "1"))
            .Build();
        var trigger = Quartz.TriggerBuilder.Create()
                    .ForJob(jobDetail)
                    .WithIdentity(new TriggerKey("test", "1"))
                    .WithSimpleSchedule()
                    .StartNow()
                    .Build();
        //.WithDailyTimeIntervalSchedule(x=>x.StartingDailyAt(new TimeOfDay(09,00)));
        Scheduler.ScheduleJob(jobDetail, trigger);
    }
