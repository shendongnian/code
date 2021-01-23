     Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
    
                object _missing = Type.Missing;
                ns.Logon(_missing, _missing, false, true);
    
                // Get Inbox information in objec of type MAPIFolder
                Microsoft.Office.Interop.Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
    
                // Unread emails
                int unread = inbox.UnReadItemCount;
    
                // Display the subject of emails in the Inbox folder
                foreach (Microsoft.Office.Interop.Outlook.Folder folds in inbox.Folders)
                {
                    Console.WriteLine(folds.Name);
                }
            
            
