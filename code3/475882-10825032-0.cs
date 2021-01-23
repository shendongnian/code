    public partial class AppDelegate : UIApplicationDelegate
    {
        public static AppDelegate Current { get; private set; }
        public UINavigationController NavController { get; private set; }
    
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            Current = this;
            NavController = new UINavigationController();
            ...
        }
    }
