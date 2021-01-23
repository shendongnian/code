    private void LogInfo(IScheduler scheduler) 
    {
        log.Info(string.Format("\n\n{0}\n", Scheduler.GetMetaData().GetSummary()));
    
        var jobGroups = scheduler.GetJobGroupNames();
        var builder = new StringBuilder().AppendLine().AppendLine();
    
        foreach (var group in jobGroups)
        {
            var groupMatcher = GroupMatcher<JobKey>.GroupContains(group);
            var jobKeys = scheduler.GetJobKeys(groupMatcher);
    
            foreach (var jobKey in jobKeys)
            {
                var detail = scheduler.GetJobDetail(jobKey);
                var triggers = scheduler.GetTriggersOfJob(jobKey);
    
                foreach (ITrigger trigger in triggers)
                {
                    builder.AppendLine(string.Format("Job: {0}", jobKey.Name));
                    builder.AppendLine(string.Format("Description: {0}", detail.Description));
                    var nextFireTime = trigger.GetNextFireTimeUtc();
                    if (nextFireTime.HasValue)
                    {
                        builder.AppendLine(string.Format("Next fires: {0}", nextFireTime.Value.LocalDateTime));
                    }
                    var previousFireTime = trigger.GetPreviousFireTimeUtc();
                    if (previousFireTime.HasValue)
                    {
                        builder.AppendLine(string.Format("Previously fired: {0}", previousFireTime.Value.LocalDateTime));
                    }
                    var simpleTrigger = trigger as ISimpleTrigger;
                    if (simpleTrigger != null)
                    {
                        builder.AppendLine(string.Format("Repeat Interval: {0}", simpleTrigger.RepeatInterval));
                    }
                    builder.AppendLine();
                }
            }
        }
    
        builder.AppendLine().AppendLine();
        log.Info(builder.ToString); 
    }
