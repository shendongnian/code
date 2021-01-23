    public static void LogSummary(string summaryMessage, ...)
    {
       HttpContext.Current.Session["userMessages"] = new UserMessage(); 
       ...
    }
    public static string DisplayUserMessages()
    {
       // get the value from session
       var userMessage = (UserMessage)HttpContext.Current.Session["userMessages"];
       // do the work
       // do the clean up
       HttpContext.Current.Session["userMessages"] = null;
       // the messages will not be displayed on next request
    }
