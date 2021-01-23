    public static class Logger
    {
     public void LogSensetiveInformation(string message)
     {
      if (!AllowedLogging(HttpContext.Current)
      {
        return;
      }
       
      LogMessage(message);// write message to some storage
     }
     public void Log(string message)
     {
      LogMessage(message);// write message to some storage
     }
    }
