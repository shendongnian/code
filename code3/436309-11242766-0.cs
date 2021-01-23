    public void LaunchSpinner()
    {
    // launch  spinner for 2 secs
    ActivityIndicator objLoadView = new ActivityIndicator ("Please Wait......");
    NSTimer.CreateScheduledTimer (TimeSpan.FromSeconds (2), () => objLoadView.StopAnimatings ());
    }
    public class ActivityIndicator : UIActivityIndicatorView
    {
    UIAlertView _alert;
    UIActivityIndicatorView _ai =new UIActivityIndicatorView();	
    public ActivityIndicator()
     {
			
     }
    public ActivityIndicator (String title)
    {
    _alert = new UIAlertView (title, String.Empty, null, null, null);
    _ai = new UIActivityIndicatorView ();
    _ai.Frame = new System.Drawing.RectangleF (125, 50, 40, 40);
    _ai.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge;
    _alert.AddSubview (_ai);
    _ai.StartAnimating ();
    _alert.Show ();	
    }
    public void StopAnimatings ()
    {			
    _ai.StopAnimating ();
    _alert.DismissWithClickedButtonIndex (0, true);
    _alert.Hidden = true;
    _ai.HidesWhenStopped = true;					
    }
    #region IDisposable implementation
    void IDisposable.Dispose ()
    {
     _alert.DismissWithClickedButtonIndex(0, true);
    }
    #endregion
    }
