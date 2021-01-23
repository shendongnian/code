    Random rnd = new Random();
    
    for (Int32 taskIdx = 0; taskIdx < 10; taskIdx++)
    {
        var taskIndex = taskIdx;
        _tasks.Add(String.Format("Task_{0}", taskIndex));
        Progress.AddItem(_tasks[taskIndex]);
    
        Int32 timeDelay = 5 + rnd.Next(10);
    
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(timeDelay);
        dispatcherTimer.Tick += (sndr, eArgs) =>
        {
            dispatcherTimer.Stop();
            Progress.SetItemStatus(taskIndex, Status.Executing);
        };
        dispatcherTimer.Start();
    }
