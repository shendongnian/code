    public partial class MainWindow : Window
    {
        private ObservableCollection<MyItem> _comboItems = new ObservableCollection<MyItem>();
        public MainWindow()
        {
            InitializeComponent();
            ComboItems.Add(new MyItem { Name = "Stack" });
            ComboItems.Add(new MyItem { Name = "Overflow" });
        }
        public ObservableCollection<MyItem> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; }
        }
    }
    public class MyItem : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
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
