    public partial class MainWindow : Window, IMainWindow
    {
        private readonly ITest test;
    
        public MainWindow(ITest test)
        {
            this.test = test;
            InitializeComponent();
        }
    
    }
