    using Windows.UI.ApplicationSettings;
    
    namespace Win8
    {
        public sealed partial class MainPage 
        {
            public MainPage()
            {
                InitializeComponent();
                SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
            }
    
            private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
            {
                var setting = new SettingsCommand("MySetting", "MySetting", handler =>
                    new MySettingsFlyout().Show());
                args.Request.ApplicationCommands.Add(setting);
            }
        }
    }
