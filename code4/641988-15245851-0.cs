    foreach (IJobSchedule schedule in _schedules)
    {
        var tmpSchedule = schedule;
        if (tmpSchedule.Enabled)
        {
            Task.Factory.StartNew(() =>
                                    {
                                        // breakpoint at line below. Inspecting "schedule.Name" always returns the name 
                                        // of the last schedule in the list. List contains 2 separate schedule items.
                                        IJob job = _kernel.Get<JobFactory>().CreateJob(tmpSchedule.Name);
                                        JobRunner jobRunner = new JobRunner(job, tmpSchedule);
                                        jobRunner.Run();
                                    },
                                    CancellationToken.None, 
                                    TaskCreationOptions.LongRunning, 
                                    TaskScheduler.Default
                                    );
        }
    } //
