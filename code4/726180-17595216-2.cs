    namespace MyNamespace
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                ...
            }
            ...
        
            private void SearchString(object sender, RoutedEventArgs e)
            {
                throw new NotImplementedException();
            }
        }
        public static class Commands
        {
            public static readonly RoutedUICommand SearchString = new RoutedUICommand("Search String", "SearchString", typeof(MainWindow));
        }
    }
