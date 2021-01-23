    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Collections.Generic;
    
    namespace WindowsFormsApplication1
    {
        public partial class ComboxBoxEx : ComboBox
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
    
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;        // x position of upper-left corner 
                public int Top;         // y position of upper-left corner 
                public int Right;       // x position of lower-right corner 
                public int Bottom;      // y position of lower-right corner 
            }
    
            public const int SWP_NOZORDER = 0x0004;
            public const int SWP_NOACTIVATE = 0x0010;
            public const int SWP_FRAMECHANGED = 0x0020;
            public const int SWP_NOOWNERZORDER = 0x0200;
    
            public const int WM_CTLCOLORLISTBOX = 0x0134;
    
            private int _hwndDropDown = 0;
    
            internal List<int> ItemHeights = new List<int>();
    
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_CTLCOLORLISTBOX)
                {
                    if (_hwndDropDown == 0)
                    {
                        _hwndDropDown = m.LParam.ToInt32();
    
                        RECT r;
                        GetWindowRect((IntPtr)_hwndDropDown, out r);
    
                        int newHeight = 0;
                        int n = (Items.Count > MaxDropDownItems) ? MaxDropDownItems : Items.Count;
                        for (int i = 0; i < n; i++)
                        {
                            newHeight += ItemHeights[i];
                        }
                        newHeight += 5; //to stop scrollbars showing
    
                        SetWindowPos((IntPtr)_hwndDropDown, IntPtr.Zero,
                            r.Left,
                                     r.Top,
                                     DropDownWidth,
                                     newHeight,
                                     SWP_FRAMECHANGED |
                                         SWP_NOACTIVATE |
                                         SWP_NOZORDER |
                                         SWP_NOOWNERZORDER);
                    }
                }
    
                base.WndProc(ref m);
            }
    
            protected override void OnDropDownClosed(EventArgs e)
            {
                _hwndDropDown = 0;
                base.OnDropDownClosed(e);
            }
        }
    }
