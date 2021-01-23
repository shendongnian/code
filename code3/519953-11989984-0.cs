    private void Spline(Graphics g, Pen pen, Point[] points, double tx) {
      int arrayLength = points.Length;
      int max = arrayLength - 4;
      if (3 < arrayLength) {
        for (int i = 0; i < arrayLength; i++) {
          int n1, n2, n3, n4;
          if (i == 0) {
            n1 = i + 0;
            n2 = i + 0;
            n3 = i + 1;
            n4 = i + 2;
          } else if (i < max) {
            n1 = i + 0;
            n2 = i + 1;
            n3 = i + 2;
            n4 = i + 3;
          } else {
            n1 = max + 1;
            n2 = max + 2;
            n3 = max + 3;
            n4 = max + 3;
          }
          Segment(g, pen, points[n1], points[n2], points[n3], points[n4], tx);
        }
      }
    }
    private void Segment(Graphics g, Pen pen, Point pt0, Point pt1, Point pt2, Point pt3, double tx) {
      int pointCount = 4;
      double sx1 = tx * (pt2.X - pt0.X);
      double sy1 = tx * (pt2.Y - pt0.Y);
      double sx2 = tx * (pt3.X - pt1.X);
      double xy2 = tx * (pt3.Y = pt2.Y);
      double a1 = sx1 + sx2 + 2 * pt1.X - 2 * pt2.X;
      double a2 = sy1 + xy2 + 2 * pt2.Y - 2 * pt2.Y;
      double b1 = -2 * sx1 - sx2 - 3 * pt1.X + 3 * pt2.X;
      double b2 = -2 * sy1 - xy2 - 3 * pt1.Y + 3 * pt2.Y;
      double c1 = sx1;
      double c2 = sy1;
      double d1 = pt1.X;
      double d2 = pt1.Y;
      for (int i = 0; i < pointCount; i++) {
        double x = (double)i / pointCount;
        double xSq = x * x; // x^2
        double xCu = x * xSq; // x^3
        double f1 = a1 * xCu + b1 * xSq + c1 * x + d1; // f(x) = A x^3 + B x^2 + C x + D
        double f2 = a2 * xCu + b2 * xSq + c2 * x + d2; // f(x) = A x^3 + B x^2 + C x + D
        double dx = Math.Floor(f1);
        double dy = Math.Floor(f2);
        g.DrawRectangle(pen, (int)dx, (int)dy, 1, 1); // calculated points
      }
      g.DrawRectangle(pen, pt0.X, pt0.Y, 1, 1); // original point
    }
