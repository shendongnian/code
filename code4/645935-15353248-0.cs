    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }
        public Dictionary<string, string> SymbolInfoText
        {
            get
            {
                return new Dictionary<string, string> { { "Error", "No Item Selected" }, { "Error1", "No Item Selected" } };
               
            }
        }
    }
