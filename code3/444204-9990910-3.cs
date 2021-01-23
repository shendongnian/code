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
        var bukkitPath = Path.Combine(ProgramLocation, String.Format("{0}{1}{2}", "Server Files", Path.DirectorySeparatorChar, "Bukkit.jar");
        CheckFile(bukkitPath, DownloadBukkitJar);
        var htmlAgilityPackPath = Path.Combine(ProgramLocation, String.Format("{0}{1}{2}", "dlls", Path.DirectorySeparatorChar, "HtmlAgilityPack.dll");
        CheckFile(htmlAgilityPackPath, DownloadHtmlAgilityPackDLL);
    }
