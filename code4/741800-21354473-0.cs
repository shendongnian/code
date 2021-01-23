    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Constants.UI
    {
    
        public class Taskbar
        {
            [DllImport("user32.dll")]// For Windows Mobile, replace user32.dll with coredll.dll
            private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll", SetLastError = true)]
            private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
    
            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);
    
            private const int SW_HIDE = 0;
            private const int SW_SHOW = 1;
    
            protected static int Handle
            {
                get
                {
                    return HandlePtr.ToInt32();
                }
            }
            protected static IntPtr HandlePtr
            {
                get
                {
                    return FindWindow("Shell_TrayWnd", "");
                }
            }
            protected static int StartHandle
            {
                get
                {
                    int hStart = FindWindow("Button", "Start").ToInt32();
                    if (hStart == 0)
                    {
                        hStart = FindWindowEx(HandlePtr, IntPtr.Zero, "Start", null).ToInt32(); //windows 8
                    }
                    return hStart;
                }
            }
    
            private Taskbar()
            {
                // hide ctor
            }
            static object lockAccess = new object();
            public static void Show()
            {
                try
                {
                    lock (lockAccess)
                    {
                        ShowWindow(Handle, SW_SHOW);
                        ShowWindow(StartHandle, SW_SHOW);
                    }
                }
                catch { }
            }
    
            public static void Hide()
            {
                try
                {
                    lock (lockAccess)
                    {
                        ShowWindow(Handle, SW_HIDE);
                        ShowWindow(StartHandle, SW_HIDE);
                    }
                }
                catch { }
            }
    }
