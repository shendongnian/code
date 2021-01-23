    public void openWordDocument(string filePath)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "WINWORD.EXE";
        startInfo.Arguments = filePath;
        Process.Start(startInfo);
    }
