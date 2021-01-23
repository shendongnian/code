    private void Form1_Load(object sender, EventArgs e)
    {
        // This requires a label titled "label1" on the form...
        // Get the UI thread's context
        var context = TaskScheduler.FromCurrentSynchronizationContext();
    
        this.label1.Text = "Starting task...";
    
        // Start a task - this runs on the background thread...
        Task task = Task.Factory.StartNew( () =>
            {
                // Do some fake work...
                double j = 100;
                Random rand = new Random();
                for (int i = 0; i < 10000000; ++i)
                {
                    j *= rand.NextDouble();
                }
    
                // It's possible to start a task directly on
                // the UI thread, but not common...
                var token = Task.Factory.CancellationToken;
                Task.Factory.StartNew(() =>
                {
                    this.label1.Text = "Task past first work section...";
                }, token, TaskCreationOptions.None, context);
    
                // Do a bit more work
                Thread.Sleep(1000);
            })
            // More commonly, we'll continue a task with a new task on
            // the UI thread, since this lets us update when our
            // "work" completes.
            .ContinueWith(_ => this.label1.Text = "Task Complete!", context);
    }
