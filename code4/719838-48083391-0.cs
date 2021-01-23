    TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
    Task.Factory.StartNew(() =>
    {
        for (int i = 0; i < 10; i++)
        {
            Task.Factory.StartNew(() =>
            {
                 listBox1.Items.Add("Number cities in problem = " + i.ToString());
            }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            System.Threading.Thread.Sleep(1000);
        }
    }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
