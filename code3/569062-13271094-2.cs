	public override bool FinishedLaunching (UIApplication app, NSDictionary options)
	{
		_window = new UIWindow (UIScreen.MainScreen.Bounds);
		_controller = new NameOfYourDialogViewController();
		_navigationController = new UINavigationController (_controller);
		UIImageView splash = new UIImageView(_window.Bounds);
		splash.Image = UIImage.FromFile("Default.png");
		
		_window.AddSubview(splash);
		_window.AddSubview(_navigationController.View);
		_window.BringSubviewToFront(splash);
		_window.MakeKeyAndVisible ();
		// This is used to create a fadding effect in your splashscreen
		UIView.Animate(1,
		        delegate { splash.Alpha = 0f; },
		        delegate {
		        	_window.RootViewController = _navigationController;
		            splash.RemoveFromSuperview();
				});
		return true;
	}
