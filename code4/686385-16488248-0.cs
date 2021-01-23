    private void Form_Load(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000); //Some long Running Tasks
                return "Finished";
            })
            .ContinueWith(t =>
                {
                    this.Text = t.Result; //Print Result
                },
                TaskScheduler.FromCurrentSynchronizationContext());
    }
