            try
            {
                
                string tomail = System.Configuration.ConfigurationManager.AppSettings["ToMailString"];
                string[] allToAddresses = tomail.Split(";,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Microsoft.Office.Interop.Outlook.Application oApp = (Microsoft.Office.Interop.Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
                //Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                //Microsoft.Office.Interop.Outlook.MailItem tempItem = (Microsoft.Office.Interop.Outlook.MailItem)Globals.ThisAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
            
                Microsoft.Office.Interop.Outlook.MailItem email = (Microsoft.Office.Interop.Outlook.MailItem)(oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem));
                email.Subject = "Status Report";
                email.Body = body;
                Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)email.Recipients;
                int mailcount1 = 1;
                for (; mailcount1 < allToAddresses.Length; mailcount1++)
                {
                    if (allToAddresses[mailcount1].Trim() != "")
                    {
                        //email.Recipients.Add(allToAddresses[mailcount1]);
                        Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(allToAddresses[mailcount1]);
                        oRecip.Resolve();
                    }
                }
                
                oRecips = null;
                ((Microsoft.Office.Interop.Outlook.MailItem)email).Send(); 
                Console.WriteLine("Mail Sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
