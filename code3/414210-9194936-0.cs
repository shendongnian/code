    using System;
    using System.Windows.Forms;
    
    namespace TestWinFormsThreding
    {
        class TestFormCotrolHelper
        {
            delegate void UniversalVoidDelegate();
    
            /// <summary>
            /// Call form controll action from different thread
            /// </summary>
            public static void ControlInvike(Control control, Action function)
            {
                if (control.IsDisposed || control.Disposing)
                    return;
    
                if (control.InvokeRequired)
                {
                    control.Invoke(new UniversalVoidDelegate(() => ControlInvike(control, function)));
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
    		TestFormCotrolHelper.ControlInvike(listView1, () => listView1.Items.Add("Test"));
    	}	
    	//...
    	}
    }
