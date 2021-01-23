    Outlook._Application oApp = new Outlook.Application();
    if (oApp.ActiveExplorer().Selection.Count > 0)
                {
                    Object selObject = oApp.ActiveExplorer().Selection[1];
    
                    if (selObject is Outlook.MailItem)
                    {
                        Outlook.MailItem mailItem = (selObject as Outlook.MailItem);
                        String htmlBody = mailItem.HTMLBody;
                        String Body = mailItem.Body;
                     }
                 }
