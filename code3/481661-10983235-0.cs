    static void OpenWordDocument()
    {
    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.EnableRaisingEvents = false;
    proc.StartInfo.FileName = @"fileName.bat";
    proc.Start();
    }
