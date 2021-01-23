    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Page1 page1 = new Page1(this);
            Frame1.Navigate(page1);
        }
        public void MainMethod() {}
    }
    
    
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }
        public Page1(MainWindow mw)
        {
            mw.MainMethod();
            InitializeComponent();
        }
    }
