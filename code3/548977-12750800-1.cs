    protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        switch (m.Msg) {
            case 0x84: //WM_NCHITTEST
                var result = (HitTest)m.Result.ToInt32();
                if (result == HitTest.Top || result == HitTest.Bottom)
                    m.Result = new IntPtr((int)HitTest.Caption);
                if (result == HitTest.TopLeft || result == HitTest.BottomLeft)
                    m.Result = new IntPtr((int)HitTest.Left);
                if (result == HitTest.TopRight || result == HitTest.BottomRight)
                    m.Result = new IntPtr((int)HitTest.Right);
    
                break;
        }
    }
    enum HitTest {
        Caption = 2,
        Transparent = -1,
        Nowhere = 0,
        Client = 1,
        Left = 10,
        Right = 11,
        Top = 12,
        TopLeft = 13,
        TopRight = 14,
        Bottom = 15,
        BottomLeft = 16,
        BottomRight = 17,
        Border = 18
    }
