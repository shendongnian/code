    var publishJobs = Sitecore.Jobs.JobManager
        .GetJobs().Where(x => x.Category.Equals("publish"))
        .ToList();
    
    publishJobs.ForEach(x => x.Status.Messages.Add("This is a message inserted by the publish:end event"));
