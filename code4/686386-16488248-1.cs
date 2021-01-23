    private void Form_Load(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000); //Some long Running Jobs
                return "Finished";
            })
            .ContinueWith(t =>
                {
                    this.Text = t.Result; //Update GUI
                },
                TaskScheduler.FromCurrentSynchronizationContext());
    }
