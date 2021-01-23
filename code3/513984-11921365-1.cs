    bool retina = false;
    if (UIScreen.MainScreen.RespondsToSelector (new MonoTouch.ObjCRuntime.Selector ("scale"))) {
    	if (UIScreen.MainScreen.Scale == 2f) {
    		retina = true;
    	}
    }
    if (retina) {
    	NSError err; // unitialized
    	UIImage img = ChangeHue (navBarImage);
    	img.AsPNG ().Save ("tempNavBar@2x.png", true, out err);
    	if (err != null && err.Code != 0) {
    		// error handling
    	}
    	UINavigationBar.Appearance.SetBackgroundImage (UIImage.FromFile ("tempNavBar.png"), UIBarMetrics.Default);
    } else {
    	UINavigationBar.Appearance.SetBackgroundImage (ChangeHue (navBarImage), UIBarMetrics.Default);
    }
