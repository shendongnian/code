    public class PastelessComboBox : ComboBox {
    
        private class TextWindow : NativeWindow {
          [StructLayout(LayoutKind.Sequential)]
          private struct RECT {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
          }
    
          private struct COMBOBOXINFO {
            public Int32 cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int buttonState;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
          }
    
          [DllImport("user32.dll", EntryPoint = "SendMessageW", CharSet = CharSet.Unicode)]
          private static extern IntPtr SendMessageCb(IntPtr hWnd, int msg, IntPtr wp, out COMBOBOXINFO lp);
    
          public TextWindow(ComboBox cb) {
            COMBOBOXINFO info = new COMBOBOXINFO();
            info.cbSize = Marshal.SizeOf(info);
            SendMessageCb(cb.Handle, 0x164, IntPtr.Zero, out info);
            this.AssignHandle(info.hwndEdit);
          }
    
          protected override void WndProc(ref Message m) {
            if (m.Msg == (0x0302)) {
              MessageBox.Show("No pasting allowed!");
              return;
            }
            base.WndProc(ref m);
          }
        }
    
        private TextWindow textWindow;
    
        protected override void OnHandleCreated(EventArgs e) {
          textWindow = new TextWindow(this);
          base.OnHandleCreated(e);
        }
    
      }
