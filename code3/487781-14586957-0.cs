    private Control _mControl;
    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
    public new void Show(Control c)
    {
        if (c == null) throw new ArgumentNullException();
        _mControl = c;
        if (this.Handle == IntPtr.Zero) base.CreateControl();
        SetParent(base.Handle, IntPtr.Zero);
        ShowWindow(base.Handle, 1);
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x86)  //WM_NCACTIVATE
        {
            if (m.WParam != IntPtr.Zero) //activate
            {
                SendMessage(_mControl.Handle, 0x86, (IntPtr)1, IntPtr.Zero);
            }
            this.DefWndProc(ref m);
            return;
        }
        base.WndProc(ref m);
    }
