    using CSharp_Settings.Settings;
    using Windows.Foundation;
    using Windows.UI.ApplicationSettings;
    using Windows.UI.Core;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
     
    namespace CSharp_Settings
    {
        public sealed partial class MainPage
        {
            public MainPage()
            {
                InitializeComponent();
                _window = Window.Current.Bounds;
                Window.Current.SizeChanged += OnWindowSizeChanged;
                SettingsPane.GetForCurrentView().CommandsRequested += CommandsRequested;
            }
     
            private Rect _window;
            private Popup _popUp;
            private const double WIDTH = 646;
     
            private void OnWindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
            {
                _window = Window.Current.Bounds;
            }
     
            private void CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
            {
                args.Request.ApplicationCommands.Add(new SettingsCommand("help", "Help", Handler));
            }
     
            private void Handler(IUICommand command)
            {
                _popUp = new Popup
                             {
                                 Width = WIDTH,
                                 Height = _window.Height,
                                 IsLightDismissEnabled = true,
                                 IsOpen = true
                             };
                _popUp.Closed += OnPopupClosed;
                Window.Current.Activated += OnWindowActivated;
                _popUp.Child = new Help_Settings {Width = WIDTH, Height = _window.Height};
                _popUp.SetValue(Canvas.LeftProperty, SettingsPane.Edge == SettingsEdgeLocation.Right ? (_window.Width - WIDTH) : 0);
                _popUp.SetValue(Canvas.TopProperty, 0);
            }
     
            private void OnWindowActivated(object sender, WindowActivatedEventArgs e)
            {
                if (e.WindowActivationState == CoreWindowActivationState.Deactivated)
                    _popUp.IsOpen = false;
            }
     
            private void OnPopupClosed(object sender, object e)
            {
                Window.Current.Activated -= OnWindowActivated;
            }
        }
    }
