    public class TextBoxWithScrollLeft : TextBox {
      private const int GWL_EXSTYLE = -20;
      private const int WS_EX_LEFTSCROLLBAR = 16384;
      [DllImport("user32", CharSet = CharSet.Auto)]
      public extern static int GetWindowLong(IntPtr hWnd, int nIndex);
      [DllImport("user32")]
      public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
      protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        int style = GetWindowLong(Handle, GWL_EXSTYLE);
        style = style | WS_EX_LEFTSCROLLBAR;
        SetWindowLong(Handle, GWL_EXSTYLE, style);
      }
    }
