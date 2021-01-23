    if (dlgOpenDir.ShowDialog() == DialogResult.OK)
    {
        fileSystemWatcher2.EnableRaisingEvents = false;  // Stop watching
        fileSystemWatcher2.IncludeSubdirectories = true;
        DestinationBox.Text = dlgOpenDir.SelectedPath;
        fileSystemWatcher2.Path = DestinationBox.Text;
        fileSystemWatcher2.EnableRaisingEvents = true;   // Begin watching
    }
