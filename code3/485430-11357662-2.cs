    SingleInstanceSynchroniser singleInstanceSynchroniser;
    protected override void OnInvoke(ScheduledTask task)
        {
            singleInstanceSynchroniser = new SingleInstanceSynchroniser();
            if (singleInstanceSynchroniser.HasExclusiveHandle)
            {
                //Run background process
                ...
            }
            else
            { //Do not run if foreground app is running
                NotifyComplete();
            }
        }
