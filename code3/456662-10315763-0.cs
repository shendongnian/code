    public static UserMessage LogSummary(string summaryMessage, bool showIndividualMessages, bool showAsError)
    {
        var userMessage = new UserMessage();
        userMessage.SummaryMessage = summaryMessage;
        userMessage.ShowMessages = showIndividualMessages;
        userMessage.ShowAsError = showAsError;
        return userMessage;
    }
