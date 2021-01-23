    static public RectangleF MeasureInkBox(Graphics graphics, string text, Font font)
    {
    	var bounds = new RectangleF();
    	using (var textPath = new GraphicsPath())
    	{
    		textPath.AddString(
    			text,
    			font.FontFamily,
    			(int)font.Style,
    			font.Size,
    			new PointF(0, 0),
    			StringFormat.GenericTypographic );
    		bounds = textPath.GetBounds();
    	}
    	return bounds;
    }
