    int count = 0;
    foreach (var item in inboxFolder.Items)
    {
        if (item is Outlook.MailItem)
        {
             Outlook.MailItem mailItem = item as Outlook.MailItem;
             if (mailItem.Subject != null && mailItem.Subject.Contains("alloc"))
             {
                 count++;
             }
        }
    }
    Debug.WriteLine("{0} are alloc emails", count);
