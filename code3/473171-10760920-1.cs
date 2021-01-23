    public partial class MainPage : PhoneApplicationPage
    {
        bool IsInputFocused = false;
        double InputHeight = 0.0;
        double KeyboardHeight = 338;
        double KeyboardClipboardHeight = 72;
        double RootHeight = 800;
        
        public MainPage()
        {
            InitializeComponent();
            DeviceStatus.KeyboardDeployedChanged += new EventHandler(DeviceStatus_KeyboardDeployedChanged);
        }
        void DeviceStatus_KeyboardDeployedChanged(object sender, EventArgs e)
        {
            if (IsInputFocused)
            {
                UpdateKeyboard();
            }
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
        private void UpdateKeyboard()
        {
            (App.Current as App).RootFrame.RenderTransform = new CompositeTransform();
            if (!DeviceStatus.IsKeyboardDeployed)
            {
                InputScrollViewer.Height = RootHeight - (KeyboardHeight + GetClipboardHeight());
            }
            else
            {
                InputScrollViewer.Height = RootHeight;
            }
        }
        private double GetClipboardHeight()
        {
            return (Clipboard.ContainsText()) ? KeyboardClipboardHeight : 0;
        }
        private void MessageText_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            IsInputFocused = true;
            (App.Current as App).RootFrame.RenderTransform = new CompositeTransform();
            UpdateKeyboard();
            Dispatcher.BeginInvoke(() =>
            {
                InputScrollViewer.ScrollToVerticalOffset(InputScrollViewer.VerticalOffset + 338 + GetClipboardHeight());
            });
        }
        private void MessageText_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            IsInputFocused = false;
            InputScrollViewer.Height = RootHeight;
        }
    }
