    private const int WM_MOVING = 0x216;
    private void WriteTheRect(IntPtr dest, Rectangle rect) {
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 0, rect.Left);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 4, rect.Top);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 8, rect.Right);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 12, rect.Bottom);
    }
    protected override void WndProc(ref Message m) {
        if (m.Msg == WM_MOVING)
        {
            // RECT structure pointed to by lParam: left, top, right, bottom
            Rectangle r = Rectangle.FromLTRB(System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 0),
                                             System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 4),
                                             System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 8),
                                             System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 12)
                                             );
            Rectangle allowed = Rectangle.FromLTRB(0, 0, 1600, 900);
            if (r.Left <= allowed.Left || r.Top <= allowed.Top || r.Right >= allowed.Right || r.Bottom >= allowed.Bottom)
            {
                int offset_x = r.Left < allowed.Left ? (allowed.Left - r.Left) : (r.Right > allowed.Right ? (allowed.Right - r.Right) : (0));
                int offset_y = r.Top < allowed.Top ? (allowed.Top - r.Top) : (r.Bottom > allowed.Bottom ? (allowed.Bottom - r.Bottom) : (0));
                r.Offset(offset_x, offset_y);
                WriteTheRect(m.LParam, r);
            }
        }
        base.WndProc(ref m);
    }
