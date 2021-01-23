    public sealed partial class App : Application
    {
        private TransitionCollection transitions;
        public static SlideApplicationFrame RootFrame { get; private set; }
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            RootFrame = Window.Current.Content as SlideApplicationFrame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (RootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                RootFrame = this.Resources["RootFrame"] as SlideApplicationFrame;
                // TODO: change this value to a cache size that is appropriate for your application
                RootFrame.CacheSize = 1;
                // Set the default language
                RootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }
                // Place the frame in the current Window
                Window.Current.Content = RootFrame;
            }
            if (RootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (RootFrame.ContentTransitions != null)
                {
                    this.transitions = new TransitionCollection();
                    foreach (var c in RootFrame.ContentTransitions)
                    {
                        this.transitions.Add(c);
                    }
                }
                RootFrame.ContentTransitions = null;
                RootFrame.Navigated += this.RootFrame_FirstNavigated;
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!RootFrame.Navigate(typeof(MainPage), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
