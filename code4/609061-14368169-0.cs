    public partial class MainWindow : Window
    {
        private ObservableCollection<MyObject> _myItems = new ObservableCollection<MyObject>();
        public MainWindow()
        {
            InitializeComponent();
            MyItems.Add(new MyObject { Name = "Test1" });
            MyItems.Add(new MyObject { Name = "Test2" });
            MyItems.Add(new MyObject { Name = "Test3" });
            MyItems.Add(new MyObject { Name = "Test4" });
        }
        public ObservableCollection<MyObject> MyItems
        {
            get { return _myItems; }
            set { _myItems = value; }
        }
        public void RemoveItems()
        {
            // Remove any items fro MyList that "IsChecked"
        }
    }
    public class MyObject : INotifyPropertyChanged
    {
        private string _name;
        private bool _isChecked;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged("IsChecked"); }
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
