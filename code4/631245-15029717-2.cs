    public class DatabaseLogger
    {
      public Logger log = null;
    
      public DatabaseLogger()
      {
        //Make sure the custom target is registered for use BEFORE using it
        ConfigurationItemFactory.Default.Targets.RegisterDefinition("DatabaseLog", typeof(DatabaseLogTarget));
 
        //initialize the log
        this.log = NLog.LogManager.GetLogger("LogDB");
      }
      
      /// <summary>
      /// Logs a trace level NLog message</summary>
      public void T(LogEventInfo info)
      {
        info.Level = LogLevel.Trace;
        this.Log(info);
      }
      
      /// <summary>
      /// Allows for logging a trace exception message to multiple log sources.
      /// </summary>
      public void T(Exception e)
      {
        this.T(FormatError(e));
      }
      
      //I also have overloads for all of the other log levels...
      
      /// <summary>
      /// Attaches the database connection information and parameter names and layouts
      /// to the outgoing LogEventInfo object. The custom database target uses
      /// this to log the data.
      /// </summary>
      /// <param name="info"></param>
      /// <returns></returns>
      public virtual void Log(LogEventInfo info)
      {
        info.Properties["dbHost"] = "SQLServer";
        info.Properties["dbDatabase"] = "TempLogDB";
        info.Properties["dbUserName"] = "username";
        info.Properties["dbPassword"] = "password";
        info.Properties["commandText"] = "exec InsertLog @LogDate, @LogLevel, @Location, @Message";
        
        info.Parameters = new DatabaseParameterInfo[] {
          new DatabaseParameterInfo("@LogDate", Layout.FromString("${date:format=yyyy\\-MM\\-dd HH\\:mm\\:ss.fff}")), 
          new DatabaseParameterInfo("@LogLevel", Layout.FromString("${level}")),
          new DatabaseParameterInfo("@Location", Layout.FromString("${event-context:item=location}")),
          new DatabaseParameterInfo("@Message", Layout.FromString("${event-context:item=shortmessage}"))
        };
    
        this.log.Log(info);
      }
    
    
      /// <summary>
      /// Creates a LogEventInfo object with a formatted message and 
      /// the location of the error.
      /// </summary>
      protected LogEventInfo FormatError(Exception e)
      {
        LogEventInfo info = new LogEventInfo();
    
        try
        {
          info.TimeStamp = DateTime.Now;
    
          //Create the message
          string message = e.Message;
          string location = "Unknown";
    
          if (e.TargetSite != null)
            location = string.Format("[{0}] {1}", e.TargetSite.DeclaringType, e.TargetSite);
          else if (e.Source != null && e.Source.Length > 0)
            location = e.Source;
    
          if (e.InnerException != null && e.InnerException.Message.Length > 0)
            message += "\nInnerException: " + e.InnerException.Message;
    
          info.Properties["location"] = location;
    
          info.Properties["shortmessage"] = message;
    
          info.Message = string.Format("{0} | {1}", location, message);
        }
        catch (Exception exp)
        {
          info.Properties["location"] = "SystemLogger.FormatError(Exception e)";
          info.Properties["shortmessage"] = "Error creating error message";
          info.Message = string.Format("{0} | {1}", "SystemLogger.FormatError(Exception e)", "Error creating error message");
        }
    
        return info;
      }
    }
