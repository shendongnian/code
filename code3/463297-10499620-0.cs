        public static List<Outlook.MAPIFolder> GetFolders()
        {
            
            List<Outlook.MAPIFolder> _list = new List<Outlook.MAPIFolder>();
            Outlook.MAPIFolder root = OutlookApplication.Session.DefaultStore.GetRootFolder();
            foreach (Outlook.MAPIFolder folder in root.Folders)
            {
                _list.Add(folder);
            }
            return _list;
        }
        public static Outlook.MAPIFolder GetFolderByEntryId(string entryId)
        {
            List<Outlook.MAPIFolder> folders = GetFolders();
            return folders.Where(x => x.EntryID == entryId).FirstOrDefault();
        }
        public static Outlook.MAPIFolder GetFolderByName(string folderName)
        {
            List<Outlook.MAPIFolder> folders = GetFolders();
            return folders.Where(x => x.Name == folderName).FirstOrDefault();
        }
