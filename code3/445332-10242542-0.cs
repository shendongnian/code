    public class TabControl2 : TabControl
    {
    	protected override void WndProc(ref Message m)
    	{
    		if (m.Msg == 0x1300 + 40)
    		{
    			RECT rc = (RECT)m.GetLParam(typeof(RECT));
    			rc.Left -= 7;
    			rc.Right += 7;
    			rc.Top -= 2;
    			rc.Bottom += 7;
    			Marshal.StructureToPtr(rc, m.LParam, true);
    		}
    		base.WndProc(ref m);
    	}
    }
    
    public struct RECT
    {
    	public int Left, Top, Right, Bottom;
    }
