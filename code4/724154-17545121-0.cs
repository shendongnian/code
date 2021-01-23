    JobTable jobTable = new JobTable();
    using(var context = new JobEntities())
    {
        jobTable.JobDate = DateTime.Now;
        jobTable.JobProcess = processName;
        context.JobTable.Add(jobTable);
        var result = context.SaveChanges();
        Console.WriteLine("Result => " + result.ToString());
        return jobTable.JobId;
    }
