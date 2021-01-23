    if (dlgOpenDir.ShowDialog() == DialogResult.OK)
    {
        fileSystemWatcher2.EnableRaisingEvents = false;  // Stop watching
        fileSystemWatcher2.IncludeSubdirectories = true;
        fileSystemWatcher2.Path = dlgOpenDir.SelectedPath;
        fileSystemWatcher2.EnableRaisingEvents = true;   // Begin watching
    }
