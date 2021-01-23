    void _background_DoWork(object sender, DoWorkEventArgs e)
    {
        // now enumeration happens in background
        foreach (var fi in DirectoryInfo.EnumerateFiles())
        {
            // main thread in used only when there is next enumeration result available
            Dispatcher.Invoke((Action)(() => dataGrid1.Items.Add(fi)));
        }
    }
