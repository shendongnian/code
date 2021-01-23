    private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form
    
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_NCLBUTTONDBLCLK)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
                base.WndProc(ref m);
            }
