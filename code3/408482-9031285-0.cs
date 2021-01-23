    public Rectangle Test(List<Point> points)
    {
    	// Add checks here, if necessary, to make sure that points is not null,
    	// and that it contains at least one (or perhaps two?) elements
    	
    	var minX = points.Min(p => p.X);
    	var minY = points.Min(p => p.Y);
    	var maxX = points.Max(p => p.X);
    	var maxY = points.Max(p => p.Y);
    	
    	return new Rectangle(new Point(minX, minY), new Size(maxX-minX, maxY-minY));
    }
