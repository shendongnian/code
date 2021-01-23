    public void RotateRectangle(Graphics g, Rectangle r, float angle) {
      using (Matrix m = new Matrix()) {
        m.RotateAt(angle, new PointF(r.Left + (r.Width / 2),
                                  r.Top + (r.Height / 2)));
        g.Transform = m;
        g.DrawRectangle(Pens.Black, r);
        g.ResetTransform();
      }
    }
