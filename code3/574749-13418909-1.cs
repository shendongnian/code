    static void LogMessage(string messageText)
    {
        string ErrorLogFileName = @"C:\temp\dataTransferErrorLog.txt";
        using (StreamWriter Log = File.AppendText(ErrorLogFileName))
        {
            try
            {
                Log.WriteLine("{0}: {1}", dateStamp, messageText);
            }
            catch(Exception) { throw; }
        }
    }
