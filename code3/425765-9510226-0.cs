        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
	       var root = new RootElement ("Welcome to MonoTouch") {
	            new Section (String.Empty) {
	                new StyledStringElement ("I'm already a MonoTouch user") {
						Accessory = UITableViewCellAccessory.DisclosureIndicator
					},
	                new StyledStringElement ("I'm new to MonoTouch") {
						Accessory = UITableViewCellAccessory.DisclosureIndicator
					}
	            }
	        };
			
			var dv = new DialogViewController (root) {
				Autorotate = true
			};
			var data = NSData.FromUrl (new NSUrl ("https://github.com/xamarin/monotouch-samples/blob/master/AVCaptureFrames/Images/Icons/114_icon.png?raw=true"));
			var logo = UIImage.LoadFromData (data);
			dv.TableView.TableHeaderView = new UIImageView (logo);
			navigation.PushViewController (dv, true);				
			
			window.MakeKeyAndVisible ();
			
			// On iOS5 we use the new window.RootViewController, on older versions, we add the subview
            if (UIDevice.CurrentDevice.CheckSystemVersion (5, 0))
				window.RootViewController = navigation;	
			else
				window.AddSubview (navigation.View);
			
			return true;
		}
