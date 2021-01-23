    public class UC_TitleBar : UserControl
    {
    	public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register("ShowCloseButton", 
    													typeof(Boolean), typeof(UC_TitleBar), new FrameworkPropertyMetadata(false));
    	public bool ShowCloseButton
    	{
    		get { return (bool)GetValue(ShowCloseButtonProperty); }
    		set { SetValue(ShowCloseButtonProperty, value); }
    	}
    }
