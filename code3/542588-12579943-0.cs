    [DllImport("User32.dll", CharSet=CharSet.Auto)]
    public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    
    _ClipboardViewerNext = SetClipboardViewer(this.Handle);
    
    protected override void WndProc(ref Message m)
    {
        switch ((Win32.Msgs)m.Msg)
        {
            case Win32.Msgs.WM_DRAWCLIPBOARD:
            // Handle clipboard changed
            break;
            // ... 
       }
    }
