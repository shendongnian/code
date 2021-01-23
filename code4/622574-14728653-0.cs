        public partial class MainWindow : Window    {
        public MainWindow()
        {
            InitializeComponent();
            _myBar.EventbtClicked += new EventHandler(UpperBarButtonClick);
        }
        protected void UpperBarButtonClick(object sender, EventArgs e)
        {
            //do something
        }
    }
