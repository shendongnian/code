    Random rnd = new Random();
    for (Int32 taskIndex = 0; taskIndex < 10; taskIndex++)
    {
        Int32 tempIndex = taskIndex;
        _tasks.Add(String.Format("Task_{0}", tempIndex));
        Progress.AddItem(_tasks[tempIndex]);
    
        Int32 timeDelay = 5 + rnd.Next(10);
    
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(timeDelay);
        dispatcherTimer.Tick += (sndr, eArgs) =>
        {
            dispatcherTimer.Stop();
            Progress.SetItemStatus(tempIndex, Status.Executing);
        };
        dispatcherTimer.Start();
    }
