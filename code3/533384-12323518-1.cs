    public partial class MainWindow : Window
    {
        public string Text1 { get; set; }
        public string Text3 { get; set; }
        public string Text2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Text1 = "10\nhello";
            Text2 = "20\nworld";
            Text3 = "30\ntesttest";
            DataContext = this;
        }
    }
