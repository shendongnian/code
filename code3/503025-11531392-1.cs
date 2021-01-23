    private const int WM_MOVING = 0x216;
    private void WriteMyRect(IntPtr dest) {
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 0, this.Left);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 4, this.Top);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 8, this.Right);
        System.Runtime.InteropServices.Marshal.WriteInt32(dest, 12, this.Bottom);
    }
    protected override void WndProc(ref Message m) {
        if (m.Msg == WM_MOVING)
        {
            // RECT structure pointed to by lParam: left, top, right, bottom
            if (System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 0) <= 0 ||
                System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 4) <= 0 ||
                System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 8) >= 1024 ||
                System.Runtime.InteropServices.Marshal.ReadInt32(m.LParam, 12) >= 768
                )
            {
                WriteMyRect(m.LParam);
            }
        }
        base.WndProc(ref m);
    }
