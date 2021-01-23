    public partial class MainWindow : Window 
    {
        private ObservableCollection<string> myVar = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            MyList.Add("test");
        }
        public ObservableCollection<string> MyList
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyList.Clear();
        }
    }
