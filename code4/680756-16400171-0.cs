        public partial class LoginViewController : UIViewController
        {
            public LoginViewController (IntPtr handle) : base (handle)
        	{
        	}
        
        	public override void ViewDidLoad ()
        	{
        		base.ViewDidLoad ();
        
        		loginWebView.LoadRequest(new NSUrlRequest(new NSUrl("http://deekor.com")));
        	}
        }
