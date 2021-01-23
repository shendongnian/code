    RunInThread<double>(
        updateProgress =>
        {
            Thread.Sleep(500);
            updateProgress(0.5);
            Thread.Sleep(500);
            updateProgress(1);
        },
        progress =>
        {
            this.Dispatcher.Invoke(() =>
            {
                progressLabel.Text = progress.ToString();
            });
        },
        () =>
        {
            this.Dispatcher.Invoke(() =>
            {
                progressLabel.Text = "Finished!";
            });
        }
    );
