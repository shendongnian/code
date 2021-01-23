	static void ManualClipping(Control clipRegionSource, Form formToClip)
	{
		var rect = clipRegionSource.DisplayRectangle;
		rect = clipRegionSource.RectangleToScreen(rect);
		rect = formToClip.RectangleToClient(rect);
		rect = Rectangle.Intersect(rect, formToClip.ClientRectangle);
		if(rect == formToClip.ClientRectangle)
		{
			formToClip.Region = null;
		}
		else
		{
			formToClip.Region = new Region(rect);
		}
	}
