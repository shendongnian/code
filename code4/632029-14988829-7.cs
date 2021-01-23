    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Test = new DelegateCommand(TestCommand);
        }
        public ICommand Test { get; set; }
        private void TestCommand()
        {
        }
    }
