    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            // Get a handle to an application window.
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName,
                string lpWindowName);
    
            // Activate an application window.
            [DllImport("USER32.DLL")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
    
            private void RefreshExplorer()
            {
                //You may want to receive the window caption as a parameter... 
                //hard-coded for now.
                // Get a handle to the current instance of IE based on window title. 
                // Using Google as an example - Window caption when one navigates to google.com 
                IntPtr explorerHandle = FindWindow("IEFrame", "Google - Windows Internet Explorer");
    
                // Verify that we found the Window.
                if (explorerHandle == IntPtr.Zero)
                {
                    MessageBox.Show("Didn't find an instance of IE");
                    return;
                }
    
                SetForegroundWindow(explorerHandle );
                //Refresh the page
                SendKeys.Send("{F5}"); //The page will refresh.
            }
        }
    }
