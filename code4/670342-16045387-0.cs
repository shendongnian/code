    public partial class MainWindow : Window
    {
        IAsyncResult cbResult;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new DirectorySearchModel();
        }
    ...
