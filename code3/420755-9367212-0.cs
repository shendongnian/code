    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Test
                {
                    Text = "Hello, World!"
                };
        }
    }
