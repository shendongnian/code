    using System;
    using System.Windows.Forms;
    
    namespace TestWinFormsThreding
    {
        class TestFormControlHelper
        {
            delegate void UniversalVoidDelegate();
    
            /// <summary>
            /// Call form control action from different thread
            /// </summary>
            public static void ControlInvoke(Control control, Action function)
            {
                if (control.IsDisposed || control.Disposing)
                    return;
    
                if (control.InvokeRequired)
                {
                    control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
                    return;
                }
                function();
            }
        }
    	
    	public partial class TestMainForm : Form
        {
    	// ...
    	// This will be called from thread not the same as MainForm thread
    	private void TestFunction()
    	{
    		TestFormCotrolHelper.ControlInvoke(listView1, () => listView1.Items.Add("Test"));
    	}	
    	//...
    	}
    }
