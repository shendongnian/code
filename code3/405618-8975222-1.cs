    public static UIImage RounderCorners (UIImage image, float width, float radius)
    {
    	UIGraphics.BeginImageContext (new SizeF (width, width));
    	var c = UIGraphics.GetCurrentContext ();
    
    				//Note: You need to write the Device.IsRetina code yourself 
    	radius = Device.IsRetina ? radius * 2 : radius;
    
    	c.BeginPath ();
    	c.MoveTo (width, width / 2);
    	c.AddArcToPoint (width, width, width / 2, width, radius);
    	c.AddArcToPoint (0, width, 0, width / 2, radius);
    	c.AddArcToPoint (0, 0, width / 2, 0, radius);
    	c.AddArcToPoint (width, 0, width, width / 2, radius);
    	c.ClosePath ();
    	c.Clip ();
    
    	image.Draw (new PointF (0, 0));
    	var converted = UIGraphics.GetImageFromCurrentImageContext ();
    	UIGraphics.EndImageContext ();
    	return converted;
    }
