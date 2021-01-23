    private void CheckFiles()
    {
        DownloadIfNeeded(ProgramLocation + "\\Server Files\\" + "Bukkit.jar");
        DownloadIfNeeded(ProgramLocation + "\\dlls\\" + "HtmlAgilityPack.dll");
    }
    
    private void DownloadIfNeeded(string s)
    {
        if (!File.Exists(s))
        {
            DownloadFile(s);
        }
        else
        {
            Close();
        }
    }
