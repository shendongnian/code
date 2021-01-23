    private void button1_Click(object sender, EventArgs e)
    {
        var uiSched = TaskScheduler.FromCurrentSynchronizationContext();
    
        button1.Enabled = false;
    
        // this HardWork-task is not blocking, as we have
        // TaskScheduler.Default as the default scheduler
        Task.Factory.StartNew(HardWork)
            .ContinueWith(t =>
            {
                button1.Enabled = true;
    
                // this HardWork-task will block, as we are on the
                // UI thread scheduler
                Task.Factory.StartNew(HardWork)
                    .ContinueWith(t2 =>
                    {
                        button1.Enabled = false;
    
                        // this one will not, as we pass TaskScheduler.Default
                        // explicitly
                        Task.Factory.StartNew(HardWork,
                            new CancellationToken(),
                            TaskCreationOptions.None,
                            TaskScheduler.Default).ContinueWith(t3 =>
                            {
                                button1.Enabled = true;
                            }, uiSched);  // come back to UI thread to alter button1
                    }, uiSched); // come back to UI thread to alter button1
            }, uiSched); // come back on UI thread to alter button1
    }
    
    public void HardWork()
    {
        int i = 0;
        while(i < Int32.MaxValue) i++;
    }
