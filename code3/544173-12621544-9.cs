    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MyViewModel();
            InitializeComponent();
        }
