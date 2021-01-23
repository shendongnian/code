    public partial class MainWindow : Window
    {
        public string TestString
        {
            get { return (string)GetValue(TestStringProperty); }
            set { SetValue(TestStringProperty, value); }
        }
            
        public static readonly DependencyProperty TestStringProperty =  DependencyProperty.Register("TestString", typeof(string), typeof(MainWindow), new UIPropertyMetadata(null));
            
        public MainWindow()
        {
            InitializeComponent();
    
            // setup the test string.
            TestString = "this is a test.";
    
            // Create the second window and pass this window as it's data context.
            Window1 newWindow = new Window1()
            {
                DataContext = this
            };
            newWindow.Show();
        }
    }
