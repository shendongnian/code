    private async void button1_Click(object sender, EventArgs e)
    {
        IProgress<int> progress = new Progress<int>(value => { progressBar1.Value = value; });
        await Task.Run(() =>
        {
            for (int i = 0; i <= 100; i++)
                progress.Report(i);
        });
    }
