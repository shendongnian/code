    private void Calculate(int i)
    {
        double pow = Math.Pow(i, i);
    }
    public void DoWork(IProgress<int> progress)
    {
        // This method is executed in the context of
        // another thread (different than the main UI thread),
        // so use only thread-safe code
        for (int j = 0; j < 100000; j++)
        {
            Calculate(j);
            // Use progress to notify UI thread that progress has
            // changed
            if (progress != null)
                progress.Report((j + 1) * 100 / 100000);
        }
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        progressBar1.Maximum = 100;
        progressBar1.Step = 1;
        var progress = new Progress<int>(v =>
        {
            // This lambda is executed in context of UI thread,
            // so it can safely update form controls
            progressBar1.Value = v;
        });
        // Run operation in another thread
        await Task.Run(() => DoWork(progress));
        // TODO: Do something after all calculations
    }
