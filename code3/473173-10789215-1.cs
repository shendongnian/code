    public partial class MainPage : PhoneApplicationPage
    {
        double InputHeight = 0.0;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }
        private void MessageText_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            (App.Current as App).RootFrame.RenderTransform = new CompositeTransform();
        }
        private void inputText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                double CurrentInputHeight = MessageText.ActualHeight;
                if (CurrentInputHeight > InputHeight)
                {
                    InputScrollViewer.ScrollToVerticalOffset(InputScrollViewer.VerticalOffset + CurrentInputHeight - InputHeight);
                }
                InputHeight = CurrentInputHeight;
            });
        }
        public void MessageText_Tap(object sender, GestureEventArgs e)
        {
            InputScrollViewer.ScrollToVerticalOffset(e.GetPosition(MessageText).Y - 80);
        }
    }
