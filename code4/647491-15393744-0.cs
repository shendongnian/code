     Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
     Microsoft.Office.Interop.Outlook.MailItem oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
     oMsg.HTMLBody = "test";
     oMsg.Subject = "test";
     Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;
     foreach (var recipient in new string[] { "a@b.c", "c@d.e" })
     {
          Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(recipient);
          oRecip.Resolve();
     }
     oRecips = null;
     oMsg.Send();
     oMsg = null;
     oApp = null;
