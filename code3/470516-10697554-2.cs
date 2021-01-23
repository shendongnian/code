    private void StartParsing()
    {
        FileParser fp = new FileParser("FileName.txt");
        fp.ProgressChanged += FileParser_ProgressChanged;
        Thread t = new Thread(fp.GenerateCmds);
        t.Start();
    }
    private void FileParser_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // switch to the UI thread if fileparser is running on a different thread
        Dispatcher.BeginInvoke(new Action(
                                  () => { progressbar.Value = e.ProgressPercentage; }));
    }
