    public class ConstrainedWindow : Window
    {
    	public ConstrainedWindow()
    	{
    		this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
    		this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
    	}
    	
    }
