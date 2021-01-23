    interface ILog
    {
       void Log(string message, int someNumber, float anotherParam, object moreParams);
    }
    
    public static class LogExtensions
    {
       public void Log(ILog this log, message)
       {
          log.Log(message, 42, 0, null); 
       }
    // more methods using ILog.Log like LogFormat that takes format string...
    }
