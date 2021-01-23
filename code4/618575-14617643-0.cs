    public partial class MainWindow : Window
    {
        private ObservableCollection<User> _myList = new ObservableCollection<User>();
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        public ObservableCollection<User> MyCollection
        {
            get { return _myList; }
            set { _myList = value; }
        }
    
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new Window1();
            if (dialog.ShowDialog() == true)
            {
                MyCollection.Add(dialog.NewUser);
            }
        }
    }
    
 
