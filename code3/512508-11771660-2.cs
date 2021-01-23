    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (sender, args) => 
            { 
                tbText.Focus(); 
                tbText.CaretIndex = tbText.Text.Length; 
            };
            DataContext = new ViewModel();
        }
    }
