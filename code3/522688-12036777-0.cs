    private void InstantSearch(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Return)
        {
            HitEnter = true;
        }
        findListText.Text = "Processing request. Please wait...";
        BackgroundWorker tempWorker = new BackgroundWorker();
        tempWorker.DoWork += delegate
        {
           Find(bool.Parse("False" as string));
        };
        tempWorker.RunWorkerAsync();
    }
