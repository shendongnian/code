    public partial class MainWindow : Window
    {
         public string Text1 { get; set; }
        public string Text2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Text1 = "10";
            Text2 = "TEST Test";
            DataContext = this;
        }
    }
