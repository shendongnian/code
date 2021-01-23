                DispatcherHelper.CheckBeginInvokeOnUI(async () =>
                {
                    try
                    {  
                        if (!this.IsActive)
                        {
                            //pressing windows button
                            InputSimulator.SimulateKeyPress(VirtualKeyCode.LWIN);
                        }
                        await Task.Delay(1000);
           
                        ApplicationRunningHelper.GetCurrentProcessOnFocus();
                    }
                    catch (Exception ex)
                    {
                     ...
                    }
                });
    
     public static class ApplicationRunningHelper
        {
            [DllImport("user32.dll")]
            private static extern bool SetForegroundWindow(IntPtr hWnd);
    
            [DllImport("user32.dll")]
            private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    
            [DllImport("user32.dll")]
            private static extern bool IsIconic(IntPtr hWnd);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
            // When you don't want the ProcessId, use this overload and pass 
            // IntPtr.Zero for the second parameter
            [DllImport("user32.dll")]
            public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
    
            [DllImport("kernel32.dll")]
            public static extern uint GetCurrentThreadId();
    
            /// The GetForegroundWindow function returns a handle to the 
            /// foreground window.
            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();
    
            [DllImport("user32.dll")]
            public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool BringWindowToTop(IntPtr hWnd);
    
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool BringWindowToTop(HandleRef hWnd);
    
            [DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
    
            //one source
            private static int SW_HIDE = 0;
            private static int SW_SHOWNORMAL = 1;
            private static int SW_SHOWMINIMIZED = 2;
            private static int SW_SHOWMAXIMIZED = 3;
            private static int SW_SHOWNOACTIVATE = 4;
            private static int SW_RESTORE = 9;
            private static int SW_SHOWDEFAULT = 10;
    
            //other source
            private static int SW_SHOW = 5;
    
            /// <summary>
            /// check if current process already running. if runnung, set focus to 
            /// existing process and returns true otherwise returns false.
            /// </summary>
            /// <returns></returns>
            public static bool GetCurrentProcessOnFocus()
            {
                try
                {
                    Process me = Process.GetCurrentProcess();
                    Process[] arrProcesses = Process.GetProcessesByName(me.ProcessName);
                    IntPtr hWnd = arrProcesses[0].MainWindowHandle;
                    ForceForegroundWindow(hWnd);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
    
            public static void ForceForegroundWindow(IntPtr hWnd)
            {
                uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                uint appThread = GetCurrentThreadId();
                const uint SW_SHOW = 5;
    
                if (foreThread != appThread)
                {
                    AttachThreadInput(foreThread, appThread, true);
                    BringWindowToTop(hWnd);
                    ShowWindow(hWnd, SW_SHOW);
                    AttachThreadInput(foreThread, appThread, false);
                }
                else
                {
                    BringWindowToTop(hWnd);
                    ShowWindow(hWnd, SW_SHOW);
                }
            }
        }
