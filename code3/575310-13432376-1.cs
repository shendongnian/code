    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        [Inject]
        public ITest Test { get; set; }
    }
    public interface IMainWindow
    {
        void Show();
    }
