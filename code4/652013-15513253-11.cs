    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _myText;
        private ObservableCollection<string> _items = new ObservableCollection<string>();
      
        public MainWindow()
        {
            InitializeComponent();
            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
            MyText = "StackOverflow";
        }
        public string MyText
        {
            get { return _myText; }
            set { _myText = value; OnPropertyChanged("MyText"); }
        }
             
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(e));
        }
    }
