    private void GetPicturesConcurrently()
    {
        Reset();
        foreach (ListViewItem item in listView1.Items)
        {
            var copy = item;
            BackgroundWorker fileCounter = new BackgroundWorker();
            fileCounter.DoWork += new DoWorkEventHandler((obj, e) => CountFilesInFolder(copy.Text));
            fileCounter.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, e) => UpdateCountListView(copy.Index));
            fileCounter.RunWorkerAsync();               
        }
    }
