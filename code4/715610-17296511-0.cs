    bool RotatedRectContains(Rectangle rect, Matrix transform, Point MousePos)
    {
      Point[] pts = { MousePos };
      Matrix inverseMat = transform.Clone();
      inverseMat.Inverse();
      inverseMat.TransformPoints(pts);
 
      return rect.Contains(pts[0]);
    }
