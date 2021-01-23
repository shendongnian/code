    class CustomDirectorySetting
    {
        public string Directory { get; set; }
        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            // your code here
        }
    }
    …
    List<CustomDirectorySetting> list = …;
    foreach (var setting in list)
    {
        var fsw = new FileSystemWatcher(setting.Directory);
        fsw.Changed += setting.OnChanged;
        fsw.EnableRaisingEvents = true;
    }
