    On App.xaml.cs
          public static Frame MainFrame{get;private set;}
          protected override void OnLaunched(LaunchActivatedEventArgs args)
                {
                    Frame rootFrame = Window.Current.Content as Frame;
                    MainFrame = rootFrame;
    (....)
                }
    Usage:
           App.MainFrame.Navigate(...);
