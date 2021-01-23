        private void RemoveItemGroup()
        {
            Outlook._Application outlookObj = new Outlook.Application();
            Outlook.MAPIFolder folder = (Outlook.MAPIFolder)
                          outlookObj.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            foreach (var curr in folder.Items.OfType<DistListItem>())
            {
                Console.WriteLine(curr.DLName);
                if (curr.DLName == "Example")
                {
                    curr.Delete();
                }
               
            }
        }
