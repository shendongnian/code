    public static class QuartzExtentionMethods
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
