    namespace WPFBuildContentTest
    {
        //App entrance point. In this case, a WPF Window
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ContentProviderImplementation cpi = new ContentProviderImplementation();
            
                TestPCLContent.TestPCLContent tpc = new TestPCLContent.TestPCLContent();
                tpc.ContentProvider = cpi; //injection
                string content = tpc.GetContent(); //loading
            }
        }
    }
