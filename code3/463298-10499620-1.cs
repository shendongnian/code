        public static List<Outlook.MailItem> GetSelectedItem()
        {
            List<Outlook.MailItem> _list = new List<Outlook.MailItem>();
            Outlook.Selection outlookSelection = OutlookApplication.ActiveExplorer().Selection;
            for (int i = 1; i < outlookSelection.Count; i++)
            {
                Outlook.MailItem mailItem = (Outlook.MailItem)outlookSelection[i];
                _list.Add(mailItem);
            }
            return _list;
        }
        public static List<Outlook.MailItem> GetMailItems(string FolderName)
        {
            List<Outlook.MailItem> _list = new List<Outlook.MailItem>();
            Outlook.MAPIFolder theFolder = OutlookApplication.Session.GetFolderFromID(GetFolderByName(FolderName).EntryID);
            foreach (Object item in theFolder.Items)
            {
                Outlook.MailItem mailItem = (Outlook.MailItem)item;
                if (mailItem != null)
                {
                    _list.Add(mailItem);
                }
            }
            return _list;
            
        }
