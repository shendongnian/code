    // backColor is an INT representation of color at fillPoint in the beginning.
    // result in pixels of enclosed shape.
    private int GetFillSize(Bitmap b, Point fillPoint)
    {
       int count = 0;
       Point p;
       Stack pixels = new Stack();
       var backColor = b.GetPixel(fillPoint.X, fillPoint.Y);
       pixels.Push(fillPoint);
       while (pixels.Count != 0)
       {
           count++;
		   
           p = (Point)pixels.Pop();
           b.SetPixel(p.X, p.Y, backColor);
           if (b.GetPixel(p.X - 1, p.Y).ToArgb() == backColor)
               pixels.Push(new Point(p.X - 1, p.Y));
           if (b.GetPixel(p.X, p.Y - 1).ToArgb() == backColor)
               pixels.Push(new Point(p.X, p.Y - 1));
           if (b.GetPixel(p.X + 1, p.Y).ToArgb() == backColor)
               pixels.Push(new Point(p.X + 1, p.Y));
           if (b.GetPixel(p.X, p.Y + 1).ToArgb() == backColor)
               pixels.Push(new Point(p.X, p.Y + 1));
       }
	   
	   return count;
    }
