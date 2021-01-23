    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Char { iXCoordinate = 20, iYCoordinate = 50 };
        }
    }
    
    public class Char
    {
        public int iXCoordinate { get; set; }
        public int iYCoordinate { get; set; }
    }
