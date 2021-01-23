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
          userMessage.ShowMessages = showIndividualMessages;
          userMessage.ShowAsError = showAsError;
          HttpContext.Current.Items["_User_Message"] = userMessage;
       }
    
       // rest of the code
       ...
    }
