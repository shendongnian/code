        private void ClearContact(Outlook.Application outlookApplication)
        {
            Outlook.MAPIFolder contactFolder = outlookApplication.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            int total = contactFolder.Items.Count;
            while (total > 0)
            {
                // first index number is 1 not 0
                var contact = (Outlook.ContactItem)contactFolder.Items[1];
                contact.Delete();
                total = contactFolder.Items.Count;
            }
        }
