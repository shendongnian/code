     public class MessageFilter : IMessageFilter
    {
        //[DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        //public static extern IntPtr WindowFromPoint(POINTSTRUCT pt);
        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(Point p);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case Constants.WM_MOUSEWHEEL:   // 0x020A
                case Constants.WM_MOUSEHWHEEL:  // 0x020E
                    IntPtr hControlUnderMouse = WindowFromPoint(new Point((int)m.LParam));
                    if (hControlUnderMouse == m.HWnd)
                        return false; // already headed for the right control
                    else
                    {
                        uint u = Convert.ToUInt32(m.Msg);   
                        SendMessage(hControlUnderMouse, u, m.WParam, m.LParam);
                        return true;
                    }
                default:
                    return false;
            }
        }
    }
