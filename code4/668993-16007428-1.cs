    public partial class Form1 : Form
    {
        private ListViewItem[] myCache; //array to cache items for the virtual list 
        private int firstItem; //stores the index of the first item in the cache
        public Form1()
        {
            InitializeComponent();
            _fileInfoCollection = new Queue<ListViewFileInfo>();
        }
        private void GetFileInformation(string drive)
        {
            _fileInfoCollection.Clear();
            var directory = new DirectoryInfo(drive);
            var files = directory.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            myCache = new ListViewItem[files.Length];
            int temp = 0;
            foreach (var file in files)
            {
                
                _fileInfoCollection.Enqueue(new ListViewFileInfo() { FileName = file.Name, FilePath = file.FullName });
                
                ListViewFileInfo fileInfo = _fileInfoCollection.Dequeue();
                var listViewItem = new ListViewItem();
                listViewItem.Text = fileInfo.FileName;
                var listViewSubItem = new ListViewItem.ListViewSubItem();
                listViewSubItem.Text = fileInfo.FilePath;
                listViewItem.SubItems.Add(listViewSubItem);
                myCache[temp] = listViewItem;
                temp++;
            }
            listView1.VirtualListSize = myCache.Length;
        }
        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
            {
                //A cache hit, so get the ListViewItem from the cache instead of making a new one.
                e.Item = myCache[e.ItemIndex - firstItem];
            }
            else
            {
                //A cache miss, so create a new ListViewItem and pass it back. 
                e.Item = new ListViewItem();
            }
        }
        private void comboBoxDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFileInformation(comboBoxDrive.Text);
        }
        private Queue<ListViewFileInfo> _fileInfoCollection;
    }
