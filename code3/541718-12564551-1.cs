    sealed partial class App : Application
    {
        private Frame _rootFrame;
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if(_rootFrame == null)
                _rootFrame = new Frame();
            // Place the frame in the current Window
            _rootFrame.Navigate(typeof (ExtendedSplash), args.SplashScreen);
            Window.Current.Content = _rootFrame;
            Window.Current.Activate();
            await PerformDataFetch();
        }
        internal async Task PerformDataFetch()
        {
            // data loading here
            RemoveExtendedSplash();
        }
        internal void RemoveExtendedSplash()
        {
            if (_rootFrame != null) _rootFrame.Navigate(typeof (MainPage));
        }
    }
