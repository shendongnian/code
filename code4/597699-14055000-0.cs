        private void RemoveItemGrupo()
        {
            OutLook._Application outlookObj = new OutLook.Application();
            OutLook.MAPIFolder folder = (OutLook.MAPIFolder)
                          outlookObj.Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderContacts);
            //int quantgrupo = 0;
            foreach (var curr in folder.Items.OfType<DistListItem>())
            {
                Console.WriteLine(curr.DLName);
                if (curr.DLName == "Exemple")
                {
                    curr.Delete();
                }
               
            }
        }
