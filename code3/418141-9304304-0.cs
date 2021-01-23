		class MyViewController : UINavigationController {
			
			public MyViewController (string s)
			{
				TabBarItem = new UITabBarItem (s, null, 1);
				var root = new RootElement (s) {
					new Section (s) {
						new StringElement (s)
					}
				};
				PushViewController (new DialogViewController (root), false);
			}
		}
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			var nav = new UITabBarController ();
			nav.ViewControllers = new UIViewController [] {
				new MyViewController ("a"),
				new MyViewController ("b"),
				new MyViewController ("c")
			};
			nav.CustomizableViewControllers = new UIViewController [0];
			
			window.RootViewController = nav;
			window.MakeKeyAndVisible ();
			return true;
		}
