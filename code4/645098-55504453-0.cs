    class Program
    {
            [DllImport("user32.dll")]
            static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);
    
    
            [DllImport("user32.dll")]
            public static extern int SetScrollPos(IntPtr hWnd, System.Windows.Forms.Orientation nBar, int nPos, bool bRedraw);
    
    
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    
    
            public struct GUITHREADINFO
            {
                public int cbSize;
                public int flags;
                public IntPtr hwndActive;
                public IntPtr hwndFocus;
                public IntPtr hwndCapture;
                public IntPtr hwndMenuOwner;
                public IntPtr hwndMoveSize;
                public IntPtr hwndCaret;
                public System.Drawing.Rectangle rcCaret;
            }
    
    
            const Int32 WM_VSCROLL = 0x0115;
            const Int32 SB_LINERIGHT = 1;
    
    
            static void Main(string[] args)
            {
                //create process in focus
                Process.Start("notepad++", "Source.cpp");
                Thread.Sleep(1000);
                GUITHREADINFO threadInfo = new GUITHREADINFO();
                threadInfo.cbSize = Marshal.SizeOf(threadInfo);
    
                GetGUIThreadInfo(0, ref threadInfo);
                SendMessage(threadInfo.hwndFocus, WM_VSCROLL, SB_LINERIGHT, 0);
                //SetScrollPos not work. Change only scrollbar without scroll window
                //SetScrollPos(threadInfo.hwndFocus, System.Windows.Forms.Orientation.Vertical, 10, true);           
            }
        }
