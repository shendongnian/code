    void pictureBox1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.Clear(Color.White);
      // draw the shading background:
      List<Point> shadePoints = new List<Point>();
      shadePoints.Add(new Point(0, pictureBox1.ClientSize.Height));
      shadePoints.Add(new Point(pictureBox1.ClientSize.Width, 0));
      shadePoints.Add(new Point(pictureBox1.ClientSize.Width,
                                pictureBox1.ClientSize.Height));
      e.Graphics.FillPolygon(Brushes.LightGray, shadePoints.ToArray());
      // scale the drawing larger:
      using (Matrix m = new Matrix()) {
        m.Scale(4, 4);
        e.Graphics.Transform = m;
        List<Point> polyPoints = new List<Point>();
        polyPoints.Add(new Point(10, 10));
        polyPoints.Add(new Point(12, 35));
        polyPoints.Add(new Point(22, 35));
        polyPoints.Add(new Point(24, 22));
        // use a semi-transparent background brush:
        using (SolidBrush br = new SolidBrush(Color.FromArgb(100, Color.Yellow))) {
          e.Graphics.FillPolygon(br, polyPoints.ToArray());
        }
        e.Graphics.DrawPolygon(Pens.DarkBlue, polyPoints.ToArray());
        foreach (Point p in polyPoints) {
          e.Graphics.FillEllipse(Brushes.Red, 
                                 new Rectangle(p.X - 2, p.Y - 2, 4, 4));
        }
      }
    }
