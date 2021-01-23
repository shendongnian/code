    sealed partial class App
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        protected override void OnWindowCreated(WindowCreatedEventArgs args)
        {
            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }
        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            var setting = new SettingsCommand("MySetting", "MySetting", handler =>
                new MySettingsFlyout().Show());
            args.Request.ApplicationCommands.Add(setting);
        }
