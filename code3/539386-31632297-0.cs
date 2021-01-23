    public static List<IJobDetail> GetJobs(this IScheduler scheduler)
    {
        List<IJobDetail> jobs = new List<IJobDetail>();
        foreach (JobKey jobKey in scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup()))
        {
            jobs.Add(scheduler.GetJobDetail(jobKey));
        }
        return jobs;
    }
