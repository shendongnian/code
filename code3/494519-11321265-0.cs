    public class ToolStripIgnoreFocus : ToolStrip {
      private const int WM_MOUSEACTIVE = 0x21;
      protected override void WndProc(ref Message m) {
        if (m.Msg == WM_MOUSEACTIVE && this.CanFocus && !this.Focused)
          this.Focus();
        base.WndProc(ref m);
      }
    }
