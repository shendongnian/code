    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Char { iXCoordinate = 20, iYCoordinate = 50 };
        }
    }
