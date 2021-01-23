    public override void ViewDidLoad ()
    {
    	base.ViewDidLoad ();
    
    	var button = UIButton.FromType(UIButtonType.RoundedRect);
    	button.Frame = new RectangleF (10, 10, 200, 30);
    	button.SetTitle ("Go Child Controller", UIControlState.Normal);
    
    	button.TouchUpInside += (object sender, EventArgs e) => {
    	    NavigationController.PushViewController(new TestController4(), true);
    	};
        
        View.AddSubview (button);
     }
