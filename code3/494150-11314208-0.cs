    public class MyRect {
      public Color FillColor { get; set; }
      public Rectangle Rectangle { get; set; }
      public MyRect(Rectangle r, Color c) {
        this.Rectangle = r;
        this.FillColor = c;
      }
    }
