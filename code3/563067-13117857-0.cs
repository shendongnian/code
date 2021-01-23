    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.Loaded += MainPage_Loaded;
        }
    
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the canvas size.
            double height = canvas.ActualHeight;
            double width = canvas.ActualWidth;
        }
    }
