    public class PastelessComboBox : ComboBox {
      [DllImport("user32.dll", SetLastError = true)]
      private static extern IntPtr FindWindowEx(IntPtr hwndParent, 
                                                IntPtr hwndChildAfter,
                                                string lpszClass,
                                                string lpszWindow);
      private class TextWindow : NativeWindow {
        public TextWindow(ComboBox cb) {
          IntPtr lhWnd = FindWindowEx(cb.Handle, IntPtr.Zero, "EDIT", null);
          this.AssignHandle(lhWnd);
        }
        protected override void WndProc(ref Message m) {
          if (m.Msg == (0x0302)) {
            MessageBox.Show("I'm not going to let you paste!");
            return;
          }
          base.WndProc(ref m);
        }
      }
      private TextWindow textWindow;
      public PastelessComboBox() {
        textWindow = new TextWindow(this);
      }
    }
