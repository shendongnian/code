    void watcher_Renamed(object sender, RenamedEventArgs e)
    {
        this.BeginInvoke(new Action(() => {
            string x = Clipboard.GetText();
            MessageBox.Show(x);
        }));
    }
