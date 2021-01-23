    private static void GetAllJobs(IScheduler scheduler)
    {
    	IList<string> jobGroups = scheduler.GetJobGroupNames();
    	IList<string> triggerGroups = scheduler.GetTriggerGroupNames();
    
    	foreach (string group in jobGroups)
    	{
    		var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
    		var jobKeys = scheduler.GetJobKeys(groupMatcher);
    		foreach (var jobKey in jobKeys)
    		{
    			var detail = scheduler.GetJobDetail(jobKey);
    			var triggers = scheduler.GetTriggersOfJob(jobKey);
    			foreach (ITrigger trigger in triggers)
    			{
    				Console.WriteLine(group);
    				Console.WriteLine(jobKey.Name);
    				Console.WriteLine(detail.Description);
    				Console.WriteLine(trigger.Key.Name);
    				Console.WriteLine(trigger.Key.Group);
    				Console.WriteLine(trigger.GetType().Name);
    				Console.WriteLine(scheduler.GetTriggerState(trigger.Key));
    				DateTimeOffset? nextFireTime = trigger.GetNextFireTimeUtc();
    				if (nextFireTime.HasValue)
    				{
    				    Console.WriteLine(TimeZone.CurrentTimeZone.ToLocalTime(nextFireTime.Value.DateTime).ToString());
    				}
    
    				DateTimeOffset? previousFireTime = trigger.GetPreviousFireTimeUtc();
    				if (previousFireTime.HasValue)
    				{
    				    Console.WriteLine(TimeZone.CurrentTimeZone.ToLocalTime(previousFireTime.Value.DateTime).ToString());
    				}
    			}
    		}
    	} 
    }
