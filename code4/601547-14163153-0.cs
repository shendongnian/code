    public class MyRTF: RichTextBox {
      private const int WM_HSCROLL = 0x114;
      private const int WM_VSCROLL = 0x115;
      protected override void WndProc(ref Message m) {
        base.WndProc(ref m);
        if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL) {
          // scrolling...
        }
      }
    }
