    private static string GetMessageBodyAsText(Message message)
    {
        try
        {
            List<MessagePart> list = message.FindAllTextVersions();
            // First let's try getting the plain text part:
            foreach (MessagePart part in list)
            {
                if (part != null)
                {
                    return part.GetBodyAsText();
                }
            }
            // Now let's try getting the HTML part
            MessagePart html = message.FindFirstHtmlVersion();
            if (html != null)
            {
                return html.GetBodyAsText();
            }
            return null;
        }
        catch (Exception exc)
        {
            // Handle your exception here
            return null;
        }
    }
