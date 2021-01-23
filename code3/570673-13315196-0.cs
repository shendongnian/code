    private void button1_Click(object sender, EventArgs e)
    {
        TaskScheduler uiContext = TaskScheduler.FromCurrentSynchronizationContext();
        Task.Run(async () =>
        {
            for (int i = 0; i < 1000; i++)
            {
                await Task.Factory.StartNew(() =>
                {
                    Controls.Add(new Label() { Text = i.ToString() });
                }, CancellationToken.None, TaskCreationOptions.None, uiContext);
            }
        });
    }
