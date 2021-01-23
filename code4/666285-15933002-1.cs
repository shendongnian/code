    private static void OnChanged(
        CustomDirectorySetting setting, FileSystemEventArgs eventArgs)
    {
        // your code here
    }
    …
    foreach (var setting in list)
    {
        var fsw = new FileSystemWatcher(setting.Directory);
        CustomDirectorySetting settingCopy = setting;
        fsw.Changed += (sender, eventArgs) => OnChanged(settingCopy, eventArgs);
        fsw.EnableRaisingEvents = true;
    }
