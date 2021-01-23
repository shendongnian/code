    const int MAX_FILE_SIZE_IN_BYTES = 5 * 1024 * 1024; //5Mb;
    const string LOG_FILE_PATH = @"ThisFolder\log.txt";
    string newLogMessage = "Hey this happened";
    #region Use one or the other, I mean you could use both below if you really want to.
    //Use this one to save an extra character
    if (!newLogMessage.StartsWith(Environment.NewLine))
        newLogMessage = Environment.NewLine + newLogMessage;
    //Use this one to imitate a write line
    if (!newLogMessage.EndsWith(Environment.NewLine))
        newLogMessage = newLogMessage + Environment.NewLine; 
    #endregion
    int newMessageSize = newLogMessage.Length*sizeof (char);
    byte[] logMessage = new byte[MAX_FILE_SIZE_IN_BYTES];
    //Append new log to end of "file"
    System.Buffer.BlockCopy(newLogMessage.ToCharArray(), 0, logMessage, MAX_FILE_SIZE_IN_BYTES - newMessageSize, logMessage.Length);
    FileStream logFile = File.Open(LOG_FILE_PATH, FileMode.Open, FileAccess.ReadWrite);
    int sizeOfRetainedLog = (int)Math.Min(MAX_FILE_SIZE_IN_BYTES - newMessageSize, logFile.Length);
    //Set start position/offset of the file
    logFile.Position = logFile.Length - sizeOfRetainedLog;
    //Read remaining portion of file to beginning of buffer
    logFile.Read(logMessage, logMessage.Length, sizeOfRetainedLog);
    //Clear the file
    logFile.SetLength(0); 
    logFile.Flush();
    //Write the file
    logFile.Write(logMessage, 0, logMessage.Length);
