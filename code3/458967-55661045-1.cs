    private int _i = 0;
    private int i
    {
        get
        {
            async void setI()
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(20);
                    i = 0;
                }
                );
            }
            setI();
            return _i;
        }
        set
        {
            _i = value;
        }
    }
    private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
    {
        if (msg == WM_CLIPBOARDUPDATE)
        {
            if(i<1)
            {
                this.ClipboardUpdate?.Invoke(this, new EventArgs());
                i++;
            }
        }
        handled = false;
        return IntPtr.Zero;
    }
