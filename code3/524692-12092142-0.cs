    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    static class DialogCloser {
        public static void Execute() {
            // Enumerate windows to find dialogs
            EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
            EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero);
            GC.KeepAlive(callback);
        }
    
        private static bool checkWindow(IntPtr hWnd, IntPtr lp) {
            // Checks if <hWnd> is a Windows dialog
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() == "#32770") {
                // Close it by sending WM_CLOSE to the window
                SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
            }
            return true;
        }
    
        // P/Invoke declarations
        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
