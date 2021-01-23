    int i = 0, flag = 5;
    var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.StartNew(() =>
    {
        while (i < flag)
        {
            Task.Factory.StartNew(() =>
            {
                this.Text = i.ToString();
            }, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            i++;
            System.Threading.Thread.Sleep(1000);
        }
    }); // <---- Removed arguments (specifically uiScheduler)
