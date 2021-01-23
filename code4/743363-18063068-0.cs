    void Application_ItemLoad(object item)
    {
        var mailItem = item as Outlook.MailItem;
        if (mailItem != null)
        {
            mailItem.Reply += MyReply;
        }
    }
