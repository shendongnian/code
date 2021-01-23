      [System.ComponentModel.BrowsableAttribute(false)]
      protected override bool ShowWithoutActivation
      {
         get { return true; }
      }
      private const int SW_SHOWNOACTIVATE = 4;
      private const int HWND_TOPMOST = 0;
      private const uint SWP_NOACTIVATE = 0x0010;
      [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
      static extern bool SetWindowPos(
           int hWnd,           // window handle 
           int hWndInsertAfter,    // placement-order handle 
           int X,          // horizontal position 
           int Y,          // vertical position 
           int cx,         // width 
           int cy,         // height 
           uint uFlags);       // window positioning flags 
      [DllImport("user32.dll")]
      static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
      public void ShowInactiveTopmost(Form frm)
      {
         ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
         SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
         frm.Left, frm.Top, frm.Width, frm.Height,
         SWP_NOACTIVATE);
      }
