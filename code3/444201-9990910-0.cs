    private void CheckFile(string path, Action action)
    {
        if (!File.Exists(path))
        {
            action();
        }
        else
        {
            Close();
        }
    }
    public void CheckFiles()
    {
        CheckFile(Path.Combine(ProgramLocation, @"Server Files\Bukkit.jar"), DownloadBukkitJar());
        CheckFile(Path.Combine(ProgramLocation, @"dlls\HtmlAgilityPack.dll"), DownloadHtmlAgilityPackDLL());
    }
