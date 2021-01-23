    string markedMessage = context.Request["message"];
    if (result.Profane)
    {
        foreach (string word in result.ProfanityWords)
        {
            markedMessage = markedMessage.Replace(
                               word, 
                               "<span class=\""profane\"">" + word + "</span>");
        }    
    }
