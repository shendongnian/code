    public class PanelImage : Panel {
      private Image image;
      public PanelImage() {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
      }
      public Image Image {
        get { return image; }
        set { 
          image = value;
          if (image != null) {
            this.AutoScrollMinSize = image.Size;
          }
          this.Invalidate();
        }
      }
      protected override void OnPaint(PaintEventArgs e) {
        e.Graphics.Clear(Color.White);
        if (image != null) {
          Point p = this.AutoScrollPosition;
          if (image.Width < this.ClientSize.Width) {
            p.X = (this.ClientSize.Width / 2) - (image.Width / 2);
          }
          if (image.Height < this.ClientSize.Height) {
            p.Y = (this.ClientSize.Height / 2) - (image.Height / 2);
          }
          e.Graphics.DrawImage(image, p);
        }
        base.OnPaint(e);
      }
    }
