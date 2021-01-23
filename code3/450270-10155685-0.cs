    // The state of our little button
    ButtonState _buttState = ButtonState.Normal;
    Rectangle _buttPosition = new Rectangle();
    
    [DllImport("user32.dll")]
    private static extern IntPtr GetWindowDC(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern int GetWindowRect(IntPtr hWnd, 
                                            ref Rectangle lpRect);
    [DllImport("user32.dll")]
    private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    protected override void WndProc(ref Message m)
    {
        int x, y;
        Rectangle windowRect = new Rectangle();
        GetWindowRect(m.HWnd, ref windowRect);
    
        switch (m.Msg)
        {
            // WM_NCPAINT
            case 0x85:
            // WM_PAINT
            case 0x0A:
                base.WndProc(ref m);
    
                DrawButton(m.HWnd);
    
                m.Result = IntPtr.Zero;
    
                break;
    
            // WM_ACTIVATE
            case 0x86:
                base.WndProc(ref m);
                DrawButton(m.HWnd);
    
                break;
    
            // WM_NCMOUSEMOVE
            case 0xA0:
                // Extract the least significant 16 bits
                x = ((int)m.LParam << 16) >> 16;
                // Extract the most significant 16 bits
                y = (int)m.LParam >> 16;
    
                x -= windowRect.Left;
                y -= windowRect.Top;
    
                base.WndProc(ref m);
    
                if (!_buttPosition.Contains(new Point(x, y)) && 
                    _buttState == ButtonState.Pushed)
                {
                    _buttState = ButtonState.Normal;
                    DrawButton(m.HWnd);
                }
    
                break;
    
            // WM_NCLBUTTONDOWN
            case 0xA1:
                // Extract the least significant 16 bits
                x = ((int)m.LParam << 16) >> 16;
                // Extract the most significant 16 bits
                y = (int)m.LParam >> 16;
    
                x -= windowRect.Left;
                y -= windowRect.Top;
    
                if (_buttPosition.Contains(new Point(x, y)))
                {
                    _buttState = ButtonState.Pushed;
                    DrawButton(m.HWnd);
                }
                else
                    base.WndProc(ref m);
    
                break;
    
            // WM_NCLBUTTONUP
            case 0xA2:
                // Extract the least significant 16 bits
                x = ((int)m.LParam << 16) >> 16;
                // Extract the most significant 16 bits
                y = (int)m.LParam >> 16;
    
                x -= windowRect.Left;
                y -= windowRect.Top;
    
                if (_buttPosition.Contains(new Point(x, y)) &&
                    _buttState == ButtonState.Pushed)
                {
                    _buttState = ButtonState.Normal;
                    // [[TODO]]: Fire a click event for your button 
                    //           however you want to do it.
                    DrawButton(m.HWnd);
                }
                else
                    base.WndProc(ref m);
    
                break;
    
            // WM_NCHITTEST
            case 0x84:
                // Extract the least significant 16 bits
                x = ((int)m.LParam << 16) >> 16;
                // Extract the most significant 16 bits
                y = (int)m.LParam >> 16;
    
                x -= windowRect.Left;
                y -= windowRect.Top;
    
                if (_buttPosition.Contains(new Point(x, y)))
                    m.Result = (IntPtr)18; // HTBORDER
                else
                    base.WndProc(ref m);
    
                break;
    
            default:
                base.WndProc(ref m);
                break;
        }
    }
    
    private void DrawButton(IntPtr hwnd)
    {
        IntPtr hDC = GetWindowDC(hwnd);
        int x, y;
    
        using (Graphics g = Graphics.FromHdc(hDC))
        {
            // Work out size and positioning
            int CaptionHeight = Bounds.Height - ClientRectangle.Height;
            Size ButtonSize = SystemInformation.CaptionButtonSize;
            x = Bounds.Width - 4 * ButtonSize.Width;
            y = (CaptionHeight - ButtonSize.Height) / 2;
            _buttPosition.Location = new Point(x, y);
    
            // Work out color
            Brush color;
            if (_buttState == ButtonState.Pushed)
                color = Brushes.LightGreen;
            else
                color = Brushes.Red;
    
            // Draw our "button"
            g.FillRectangle(color, x, y, ButtonSize.Width, ButtonSize.Height);
        }
    
        ReleaseDC(hwnd, hDC);
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        _buttPosition.Size = SystemInformation.CaptionButtonSize;
    }
