    public class MailFolder
    {
        public string Name { get; set; }
        public ObservableCollection<MailItem> Items
        {
            get
            {
                return items ?? (items = new ObservableCollection<MailItem>());
            }
        }
        private ObservableCollection<MailItem> items;
       
        public ObservableCollection<MailFolder> SubFolders
        {
            get
            {
                return subFolders ?? (subFolders = new ObservableCollection<MailFolder>());
            }
        }
        private ObservableCollection<MailFolder> subFolders;
    }
    public class MailItem
    {
        public string Subject { get; set; }
    }
