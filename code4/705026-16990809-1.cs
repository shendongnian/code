    class RichBox : RichTextBox {
      private const int WM_PAINT = 15;
      protected override void WndProc(ref Message m) {
        if (m.Msg == WM_PAINT) {
          this.Invalidate();
          base.WndProc(ref m);
          using (Graphics g = Graphics.FromHwnd(this.Handle)) {
            g.DrawLine(Pens.Red, Point.Empty, 
                       new Point(this.ClientSize.Width - 1,
                                 this.ClientSize.Height - 1));
          }
        } else {
          base.WndProc(ref m);
        }
      }
    }
