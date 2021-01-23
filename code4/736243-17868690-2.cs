    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            protected static extern int GetWindowTextLength(IntPtr hWnd);
    
            [DllImport("user32.dll", EntryPoint = "FindWindow")]
            private static extern IntPtr FindWindow(string lp1, string lp2);
    
            [DllImport("user32.dll")]
            protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
    
            [DllImport("user32.dll")]
            protected static extern bool IsWindowVisible(IntPtr hWnd);
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
    
            private static void Main(string[] args)
            {
                EnumWindows(EnumTheWindows, IntPtr.Zero);
    
                Console.ReadLine();
            }
    
            static uint WM_CLOSE = 0x10;
    
            protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
            {
                int size = GetWindowTextLength(hWnd);
                if (size++ > 0 && IsWindowVisible(hWnd))
                {
                    StringBuilder sb = new StringBuilder(size);
                    GetWindowText(hWnd, sb, size);
                    if (sb.ToString().StartsWith("Untitled"))
                        SendMessage(hWnd, WM_CLOSE, 0, 0);
                }
                return true;
            }
        }
    }
