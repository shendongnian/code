    using Quartz;
    using Quartz.Impl.Matchers;
    using Quartz.Collection;
    using System.Linq;
    
    ISet<JobKey> jobKeys = _scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(SchedulerConstants.DefaultGroup));
    JobKey key = jobKeys.Where(x => x.Name == jobName).First();
    IJobDetail jobData = _scheduler.GetJobDetail(key);
