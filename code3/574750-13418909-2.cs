    static void LogMessage(string messageText)
    {
        try
        {
            string ErrorLogFileName = @"C:\temp\dataTransferErrorLog.txt";
            using (StreamWriter Log = File.AppendText(ErrorLogFileName))
            {
                Log.WriteLine("{0}: {1}", dateStamp, messageText);
            }
         }
         catch(Exception) { throw; }
    }
