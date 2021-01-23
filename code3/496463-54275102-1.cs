    public static void OpenWithDefaultProgram(string path)
    {
        Process fileopener = new Process();
        fileopener.StartInfo.FileName = "explorer";
        fileopener.StartInfo.Arguments = "\"" + path + "\"";
        fileopener.Start();
    }
