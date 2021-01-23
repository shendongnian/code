    public override bool FinishedLaunching (UIApplication app, NSDictionary options)
    {
        window = new UIWindow (UIScreen.MainScreen.Bounds);
    	rootController = new UINavigationController ();
    	window.RootViewController = rootController;
    
    	var tabController = new UITabBarController ();
    
    	var vc1 = new TestController1();
    	var vc2 = new TestController2();
    	var vc3 = new TestController3();
    
        tabController.ViewControllers = new UIViewController[] {
    	    vc1,
    	    vc2,
    	    vc3
    	};
    
    	tabController.ViewControllers [0].TabBarItem.Title = "vc1";
    	tabController.ViewControllers [1].TabBarItem.Title = "vc2";
    	tabController.ViewControllers [2].TabBarItem.Title = "vc3";
    
    	this.rootController.PushViewController(tabController, false);
    
    	window.MakeKeyAndVisible ();
    			
    	return true;
    }
