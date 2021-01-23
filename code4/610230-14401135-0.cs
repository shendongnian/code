    public class ScrollControl : ScrollableControl {
      public ScrollControl() {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
        this.AutoScrollMinSize = new Size(0, 600);
      }
      protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        e.Graphics.Clear(Color.White);
        e.Graphics.TranslateTransform(this.AutoScrollPosition.X, 
                                      this.AutoScrollPosition.Y);
        e.Graphics.FillRectangle(Brushes.Red, new Rectangle(16, 32, 64, 32));
      }
    }
