    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new ViewModel();
            }
        }
    }
