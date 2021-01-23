    public class ClsCapture
    {
    	bool bCaptureMe;
    	Point pLocation = new Point();
    
    	Control dd;
    	//Handles dad.MouseDown, dd.MouseDown
    	private void Form1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    	{
    		try {
    			bCaptureMe = true;
    			pLocation = e.GetPosition(sender);
    		} catch {
    		}
    	}
    
    	//Handles dad.MouseMove, dd.MouseMove
    	private void Form1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    	{
    		try {
    
    			if (bCaptureMe) {
    				dd.Margin = new Thickness(dd.Margin.Left - pLocation.X + e.GetPosition(sender).X, dd.Margin.Top - pLocation.Y + e.GetPosition(sender).Y, dd.Margin.Right, dd.Margin.Bottom);
    
    			}
    		} catch {
    		}
    	}
    
    	//Handles dad.MouseUp, dd.MouseUp
    	private void Form1_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    	{
    		try {
    			bCaptureMe = false;
    		} catch {
    		}
    	}
    
    	public ClsCapture(Control pnl)
    	{
    		dd = pnl;
    		dd.PreviewMouseLeftButtonDown += Form1_MouseDown;
    		dd.PreviewMouseLeftButtonUp += Form1_MouseUp;
    		dd.PreviewMouseMove += Form1_MouseMove;
    	}
    
    	public static void CaptureMe(Control pnl)
    	{
    		ClsCapture cc = new ClsCapture(pnl);
    	}
    
    }
