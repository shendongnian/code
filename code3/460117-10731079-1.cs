    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,          string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        
         static void Send(string message)
         {
             Process[] notepads = Process.GetProcessesByName("notepad");
             if (notepads.Length == 0)
                 return;
             if (notepads[0] != null)
             {
                 IntPtr child = FindWindowEx(notepads[0].MainWindowHandle, 
                     new IntPtr(0), "Edit", null);
                 SendMessage(child, 0x000C, 0, message);
             }
         }
    
    
