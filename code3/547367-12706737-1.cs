    void _background_DoWork(object sender, DoWorkEventArgs e)
    {
        var info = new DirectoryInfo(System.IO.Path.GetTempPath());
        // now enumeration happens in background
        foreach (var fi in info.EnumerateFiles())
        {
            // main thread in used only when there is next enumeration result available
            Dispatcher.Invoke((Action)(() => dataGrid1.Items.Add(fi)));
        }
    }
