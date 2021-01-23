    public static bool IsWithin(Ellipse item, Point lastPosition)
            {
                // Get the center  of the elipse
                Point center = new Point(
                        Canvas.GetLeft(item) + (item.Width / 2),
                        Canvas.GetTop(item) + (item.Height / 2));
    
                EllipseGeometry eg = new EllipseGeometry();
                eg.Center = center;
                eg.RadiusX = item.Width / 2;
                eg.RadiusY = item.Height / 2;
    
                return eg.Bounds.Contains(lastPosition);
            }  
          
