    private void CheckFile(string path, Action actionIfMissing)
    {
        if (!File.Exists(path))
        {
            actionIfMissing();
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
