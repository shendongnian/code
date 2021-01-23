        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;
            // Standard Silverlight initialization
            InitializeComponent();
            // Phone-specific initialization
            InitializePhoneApplication();
            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;
                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;
                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;
                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }
            RootFrame.Navigating += new NavigatingCancelEventHandler(RootFrame_Navigating);
        }
        void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.Uri.ToString().Contains("/MainPage.xaml") != true)
            {
                return;
            }
            e.Cancel = true;
            RootFrame.Dispatcher.BeginInvoke(delegate
            {
                if (System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Contains("Login_Credentials"))
                {
                    RootFrame.Navigate(new Uri("/B.xaml", UriKind.Relative));
                }
                else
                {
                    RootFrame.Navigate(new Uri("/A.xaml", UriKind.Relative));
                }
            });
        }
