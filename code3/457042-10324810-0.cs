    foreach (Trigger trigger in Scheduler.GetTriggersOfJob(jobName, group))
    {
    
        if (trigger is CronTrigger)
        {
    
            CronTrigger cronTrigger = trigger as CronTrigger;
            if (cronTrigger != null)
            {
                cronTrigger.CronExpressionString = "Your Updated Cron Strin";
            }
        }
    }  
