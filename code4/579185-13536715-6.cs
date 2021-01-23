    private void CloseAfter(int duration, TaskScheduler ui)
    {
        Thread.Sleep(duration * 1000);
        Form form = this;
        for (double i = 0.98; i > 0; i -= 0.05)
        {
            Task.Factory.StartNew(
                () => form.Opacity = i,
                CancellationToken.None,
                TaskCreationOptions.None,
                ui);
            Thread.Sleep(50);
        }
        Task.Factory.StartNew(
            () => form.Close(),
            CancellationToken.None,
            TaskCreationOptions.None,
            ui);
    }
