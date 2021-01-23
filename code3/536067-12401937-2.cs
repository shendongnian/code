    using System;
    using System.Timers;
    using System.Windows.Forms;
    
    
    public class SwitchForms : IDisposable
    {
    	private Form Form1 { get; set; }
    	
    	private Form Form2 { get; set; }
    	
    	private Timer VisibilityTimer { get; set; }
    	
    	
    	public SwitchForms(Form form1, Form form2, int hideMinutes)
    	{
    		Form1 = form1;
    		Form2 = form2;
    	
    		VisibilityTimer = new Timer(hideMinutes * 60 * 1000);
    		VisibilityTimer.Elapsed += new VisibilityTimer_Elapsed);
    		VisibilityTimer.Enabled = true;
    		
    		
    		Form1.Invoke(new MethodInvoker(() => { Form1.Visible = true; });
    		Form2.Invoke(new MethodInvoker(() => { Form2.Visible = false; });
    		
    	}
    
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
    		Form1.Invoke(new MethodInvoker(() => { Form1.Visible = !Form1.Visible });
    		Form2.Invoke(new MethodInvoker(() => { Form2.Visible = !Form2.Visible });
        }
    	
    	public void Dispose()
    	{
    		VisibilityTimer.Enabled = False;
    		VisibilityTimer.Dispose();
    	}
    
    
    }
