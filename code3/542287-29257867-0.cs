    private Object fileLock = new Object();
    private void WriteLog(string line)
    {
        lock (fileLock)
        {
            string strNomLog = @".\MyFile.log";
            System.IO.File.AppendAllText(strNomLog, line);
        }
    }
