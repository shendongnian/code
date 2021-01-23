    public static class QuartzExtensionMethods
    {
        public static string ToCronString(this CronScheduleBuilder cronSchedule)
        {
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder
            .Create()
            .WithSchedule(cronSchedule)
            .Build();
            return trigger.CronExpressionString;
        }
    }
