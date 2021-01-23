      using Microsoft.Phone.Shell;
    
     public partial class MainPage : PhoneApplicationPage
        {
            private ProgressIndicator _progressIndicator;
    
            public MainPage()
            {
                InitializeComponent();
    
                _progressIndicator = new ProgressIndicator
                {
                    IsIndeterminate = true,
                    Text = "Loading...",
                    IsVisible = true,
                };
    
                SystemTray.SetIsVisible(this, true);
                SystemTray.SetProgressIndicator(this, _progressIndicator);
                SystemTray.SetOpacity(this, 1);
    
                //something is a very long here
    
                _progressIndicator.IsVisible = false;
                SystemTray.SetIsVisible(this, false);
            }
        }
