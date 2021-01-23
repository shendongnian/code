    public override void FeatureActivated(SPFeatureReceiverProperties properties)
    {
        SPWeb web = properties.Feature.Parent as SPWeb;
        NotifyJob oJob = new NotifyJob("TestJob", web.Site.WebApplication);
        SPMinuteSchedule schedule = new SPMinuteSchedule();
        schedule.BeginSecond = 0;
        schedule.EndSecond = 59;
        schedule.Interval = 30;
        oJob.Schedule = schedule;
        oJob.Update();
    }
