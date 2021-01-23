	public override void ViewDidLoad ()
	{
		base.ViewDidLoad ();
		// Do your stuff
	}
	public override void ViewWillAppear (bool animated)
	{
		base.ViewWillAppear (animated);
		this.ReloadData();
	}
