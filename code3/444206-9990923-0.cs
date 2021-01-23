    private void CheckFiles()
    {
        bool bukkitExists = File.Exists(ProgramLocation + "\\Server Files\\" + "Bukkit.jar");
        if (!bukkitExists)
        {
            DownloadBukkitJar();
        }
        bool agilityExists = File.Exists(ProgramLocation + "\\dlls\\" + "HtmlAgilityPack.dll");
        if (!agilityExists)
        {
            DownloadHtmlAgilityPackDll();
        }
        if (bukkitExists || agilityExists)
        {
            Close();
        }
    }
