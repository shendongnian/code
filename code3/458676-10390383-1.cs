    public partial class MainWindowResourceDictionary : ResourceDictionary
    {
        public MainWindowResourceDictionary()
        {
            InitializeComponent();
        }
    
        private void HelpExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var fooViewModel = (FooViewModel)((FrameworkElement)e.Source).DataContext;
            fooViewModel.HelpExecuted();
        }
    }
