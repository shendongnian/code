    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace keybound
    {
    class WindowHook
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        public static void sendKeystroke(ushort k)
        {
            const uint WM_KEYDOWN = 0x100;
            const uint WM_SYSCOMMAND = 0x018;
            const uint SC_CLOSE = 0x053;
            IntPtr WindowToFind = FindWindow(null, "Untitled1 - Notepad++");
            IntPtr result3 = SendMessage(WindowToFind, WM_KEYDOWN, ((IntPtr)k), (IntPtr)0);
            //IntPtr result3 = SendMessage(WindowToFind, WM_KEYUP, ((IntPtr)c), (IntPtr)0);
        }
    }
    }
