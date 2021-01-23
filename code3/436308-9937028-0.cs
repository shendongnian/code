    public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
		    UIImageView splash = new UIImageView(window.Bounds);
		    splash.Image = UIImage.FromFile("Default.png");
			var vc = new UIViewController ();
			var nav = new UINavigationController(vc);
			
			window.AddSubview(splash);
			window.AddSubview(nav.View);
			window.BringSubviewToFront(splash);
			window.MakeKeyAndVisible();
			
			UIView.Animate(5,
		    delegate
		    {
		        splash.Alpha = 0f;
		    },
		    delegate
		    {
		        Console.WriteLine("Removed.");
			window.RootViewController = nav;
		        splash.RemoveFromSuperview();
		        
		    });
		
		    return true;
		}
