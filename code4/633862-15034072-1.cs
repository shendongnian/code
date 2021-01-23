    public partial class MainWindow : Window
    {
        public string Foo { get; set; }
        public MainWindow()
        {
            Foo = "hello world"; // Changing Foo 'automagically' changes your textblock value
            InitializeComponent();
        }
    }
