    private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
    {
        if (e.Name == "myIcon.ico")
        {
            this.Icon = new Icon(e.FullPath);
        }
    }
