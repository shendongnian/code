    sealed partial class App : Application
    {
        public static Frame RootFrame { get; private set; }
        
        ...
        
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = this.RootFrame = Window.Current.Content as Frame;
