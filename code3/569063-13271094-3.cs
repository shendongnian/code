	public NameOfYourDialogViewController() : base (UITableViewStyle.Grouped, null)
	{
		Root = new RootElement ("test") {
			new Section ("First Section"){
				new StringElement ("Hello", () => {
					new UIAlertView ("Hola", "Thanks for tapping!", null, "Continue").Show (); 
				}),
				new EntryElement ("Name", "Enter your name", String.Empty)
			},
			new Section ("Second Section"){
			},
		};
		}
	}
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
