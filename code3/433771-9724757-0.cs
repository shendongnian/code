    public void LogSensetiveInformation(string message)
    {
     if (!AllowedLogging(HttpContext.Current)
     {
       return;
     }
    
     // write message to some storage
    }
