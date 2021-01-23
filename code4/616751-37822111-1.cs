    IUnityContainer container = new UnityContainer();
    container.AddNewExtension<Quartz.Unity.QuartzUnityExtension>();
    // do your other Unity registrations
    IScheduler scheduler = container.Resolve<IScheduler>();
    scheduler.ScheduleJob(
        new JobDetailImpl(myCommandName, typeof(MyCommand)),
        TriggerBuilder.Create()
            .WithCronSchedule(myCronSchedule)
            .StartAt(startTime)
            .Build()
    );
    scheduler.Start();
