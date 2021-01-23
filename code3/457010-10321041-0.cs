    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string data)
            : this()
        {
            label1.Content = data;
        }
    }
    
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
             string mytext = "blabla";
             MainWindow fromloginwindow = new MainWindow(mytext); 
        }
    }
