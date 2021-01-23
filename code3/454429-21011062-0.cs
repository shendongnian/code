    public override void DrawRect (RectangleF dirtyRect)
		{
			NSString s = new NSString ("test");
			s.DrawString (new PointF(25,100), new NSDictionary ());
		}
