    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.Clear(Color.White);
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (Pen pen = new Pen(Color.Black, 4)) {
        pen.StartCap = Drawing2D.LineCap.Flat;
        pen.EndCap = Drawing2D.LineCap.ArrowAnchor;
        int x1, x2, y1, y2;
        //choose x/y coordinates
        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
      }
      base.OnPaint(e);
    }
