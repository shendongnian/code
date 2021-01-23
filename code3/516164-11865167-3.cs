    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new[] 
            { 
                new ViewModel { RelativeWidth = 20 },
                new ViewModel { RelativeWidth = 40 },
                new ViewModel { RelativeWidth = 60 },
                new ViewModel { RelativeWidth = 100 },
            };
        }
    }
