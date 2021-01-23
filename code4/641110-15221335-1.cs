    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonGroups.Add(MyEnum.Home, new Button { Content = "Hello" });
            NotifyPropertyChanged("ButtonGroups");
        }
        private Dictionary<MyEnum, Button> _buttonGroups = new Dictionary<MyEnum, Button>();
        public Dictionary<MyEnum, Button> ButtonGroups
        {
            get { return _buttonGroups; }
            set { _buttonGroups = value; }
        }
        public enum MyEnum
        {
            Home,
            Report
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
