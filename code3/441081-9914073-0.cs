    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Wb.Navigated += new EventHandler<System.Windows.Navigation.NavigationEventArgs>(Wb_Navigated);
            MouseLeftButtonDown += new MouseButtonEventHandler(MainPage_MouseLeftButtonDown);
            Wb.NavigateToString("<html><body><form action='http://google.com/'></form></body></html>");
        }
        void Wb_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Wb.InvokeScript("eval", "document.forms[0].submit();"); // Throws 80020101
        }
        private void MainPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Wb.InvokeScript("eval", "document.forms[0].submit();"); // Works
        }
    }
