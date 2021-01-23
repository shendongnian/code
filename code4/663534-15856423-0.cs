        //Import the FindWindow API to find our window
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindowNative(string className, string windowName);
        //Import the SetForeground API to activate it
        [DllImport("User32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern IntPtr SetForegroundWindowNative(IntPtr hWnd);
        public static IntPtr FindWindow(string className, string windowName)
        {
            return FindWindowNative(className, windowName);
        }
        public static IntPtr SetForegroundWindow(IntPtr hWnd)
        {
            return SetForegroundWindowNative(hWnd);
        }
    }
    internal class Program : Application
    {
        private static void Activate(string title)
        {
            //Find the window, using the Window Title
            IntPtr hWnd = Win32.FindWindow(null, title);
            if (hWnd.ToInt32() > 0) //If found
            {
                Win32.SetForegroundWindow(hWnd); //Activate it
            }
        }
        [STAThread]
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            // Get Reference to the current Process
            var thisProc = Process.GetCurrentProcess();
            // Check how many total processes have the same name as the current one
            if (Process.GetProcessesByName(thisProc.ProcessName).Length > 1)
            {
                Activate("active dictionary");
                Current.Shutdown();
                return;
            }
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
