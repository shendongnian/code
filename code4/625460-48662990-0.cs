    internal static IEnumerable<MailItem> GetSelectedEmails()
            {
                foreach (MailItem email in new Microsoft.Office.Interop.Outlook.Application().ActiveExplorer().Selection)
                {
                    yield return email;
                }
            }
