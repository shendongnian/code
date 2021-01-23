    public partial class MainWindow : Window
    {
            private WindowData _data = new WindowData();
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = _data;
            }
    }
