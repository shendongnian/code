    internal static class LabelBorder {
      public static void ColorMe(Rectangle r, PaintEventArgs e) {
        r.Inflate(-1, -1);
        using (Pen p = new Pen(Color.FromArgb(104, 195, 198), 1))
          e.Graphics.DrawRectangle(p, r);
      }
    }
