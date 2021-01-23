    public class MyForm : Form
    {
    	// other code
    	
    	protected override void WndProc(ref Message m)
    	{
    	    switch (m.Msg)
    	    {
    	    	case WM_NCACTIVATE:
    	    	{
    	    	    SystemSounds.Beep.Play();
    	    	    break;	
    	    	}
    	    	base.WndProc(ref m);  // proceed with default processing
    	    }
    	}
    }
    
