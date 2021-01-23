    public class UserMessage
    {
       public static UserMessage Current
       {
          get { return HttpContext.Current.Items["_User_Message"] as UserMessage; }
       }
    
       public static void LogSummary(string summaryMessage, bool showIndividualMessages, bool showAsError)
       {
          var userMessage = new UserMessage();
          userMessage.SummaryMessage = summaryMessage;
          ...  
          HttpContext.Current.Items["_User_Message"] = userMessage;
       }
    
       public static string DisplayUserMessages()
       {
           var userMessage = UserMessage.Current;
           if (userMessage == null ) return string.Empty;
           ...
       }
       // rest of the code
       ...
    }
