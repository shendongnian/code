    public partial class MainWindow : Window
    {
        IAsyncResult cbResult;
        DirectorySearchModel _model = new DirectorySearchModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _model;
        }
    ...
