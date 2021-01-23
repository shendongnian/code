    private const int WM_LBUTTONDBLCLK = 0x0203;
    
    ...
    
    protected override void WndProc(ref Message message) {
      if (message.Msg == WM_LBUTTONDBLCLK) {
        return;
      }
       
      base.WndProc(ref message);
    
      if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
        message.Result = (IntPtr)HTCAPTION;
    }
