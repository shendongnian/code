    public void WriteLog(string logMessage)
    {
        using (var logFile = File.AppendText(logFilePath))
        {
            logFile.WriteLine(DateTime.Now);
            logFile.WriteLine(logMessage);
            logFile.WriteLine();
        }
    }
