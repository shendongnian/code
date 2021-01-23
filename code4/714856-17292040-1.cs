    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new VMColl();
        }
    }
    public class VMColl
    {
        List<VM> source;
        public List<VM> Source
        {
            get { return source; }
            set { source = value; }
        }
        public VMColl()
        {
            source  = new List<VM>(){new VM(),new VM(),new VM(),new VM()};
        }
    }
    /// <summary>
    /// your Row
    /// </summary>
    public class VM : Notify
    {
        private List<mainObj> _items;
        public List<mainObj> SomeBinding
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
        private string _selectedName;
        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                _selectedName = value;
                OnPropertyChanged("SelectedName");
            }
        }
        private mainObj _selectedMainItem;
        public mainObj SelectedMainItem
        {
            get { return _selectedMainItem; }
            set
            {
                _selectedMainItem = value;
                OnPropertyChanged("SelectedMainItem");
                OnPropertyChanged("SelectedMainItem.Subitems");
            }
        }
        private string _selectedSubitem;
        public string SelectedSubitem
        {
            get { return _selectedSubitem; }
            set
            {
                _selectedSubitem = value;
                OnPropertyChanged("SelectedSubitem");
            }
        }
        public VM()
        {
            SomeBinding = new List<mainObj>() {new mainObj("first"),new mainObj("second"),new mainObj("someother") };
        }
    }
    public class mainObj : Notify
    {
        private BindingList<string> _subitems;
        public BindingList<string> Subitems
        {
            get { return _subitems; }
            set
            {
                _subitems = value;
                OnPropertyChanged("Subitems");
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public mainObj(string name)
        {
            _name = name;
            _subitems = new BindingList<string>(){"1","2","3"};
        }
    }
    public class Notify : INotifyPropertyChanged
    {
        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
