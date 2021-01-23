    sealed partial class App : Application
    {
        public static Frame RootFrame { get; private set; }
        
        ...
                
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = this.RootFrame = Window.Current.Content as Frame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = this.RootFrame = new Frame();
                ...
