    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _myProperty = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            MyProperty.CollectionChanged += MyProperty_CollectionChanged;
        }
        public ObservableCollection<string> MyProperty
        {
            get { return _myProperty; }
            set { _myProperty = value; }
        }
        void MyProperty_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Collection Changed
        }
    }
