    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            //  foreach (var qs in qss)
            for (int i = 0; i < 50; i++)
            {
                // TreeItems.Add(qs);
                TreeItems.Add(new MyObject { SetName = "Test1" }); 
            }
        } 
        private ObservableCollection<MyObject> _treeItems = new ObservableCollection<MyObject>();
        public ObservableCollection<MyObject> TreeItems
        {
            get { return _treeItems; }
            set { _treeItems = value; }
        }
    }
    // Your "qs" object
    public class MyObject : INotifyPropertyChanged
    {
        private string _folderImage;
        public string FolderImage
        {
            get { return _folderImage; }
            set { _folderImage = value; NotifyPropertyChanged("FolderImage"); }
        }
        private string _setname;
        public string SetName
        {
            get { return _setname; }
            set { _setname = value; NotifyPropertyChanged("SetName"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
