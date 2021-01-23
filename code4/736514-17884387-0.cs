        [Register ("AppDelegate")]
    	public partial class AppDelegate : UIApplicationDelegate
    	{
    		// class-level declarations
    		UIWindow window;
    		UINavigationController rootNavigationController;
                    
            public override bool FinishedLaunching (UIApplication app, NSDictionary options)
            {
                this.window = new UIWindow (UIScreen.MainScreen.Bounds); 
                //---- instantiate a new navigation controller 
                this.rootNavigationController = new UINavigationController(); 
                this.rootNavigationController.PushViewController(new MyUITableViewController(), false);
                
                //---- set the root view controller on the window. the nav 
                // controller will handle the rest
                this.window.RootViewController = this.rootNavigationController;
                this.window.MakeKeyAndVisible (); 
                return true;
            }
    
            .... 
    
    
