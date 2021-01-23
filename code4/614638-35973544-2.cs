    public static void Debug(this ILogger logger, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
    {
      return (format, args)
      {
        LogWithCallerSiteInfo(format, args, callerMemberName, callerFilePath, callerLineNumber, logAction);
      }
    }
