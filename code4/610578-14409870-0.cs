    public partial class MainWindow : Window
    {
        private MainViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainViewModel()
            {
                Name = "MyViewModel",
                ...
            };
            this.DataContext = _vm;
        }
