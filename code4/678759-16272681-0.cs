    private void CreateUrlShortcut(string linkName, string linkUrl)
    {
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
    
        using (StreamWriter writer = new StreamWriter(dir + "\\" + linkName + ".url"))
        {
            writer.WriteLine("[InternetShortcut]");
            writer.WriteLine("URL=" + linkUrl);
            writer.Flush();
        }
    }
