    public const double DPI = 96;
    /// <summary>
    /// This tells a visual to render itself to a wpf bitmap
    /// </summary>
    /// <remarks>
    /// This fixes an issue where the rendered image is blank:
    /// http://blogs.msdn.com/b/jaimer/archive/2009/07/03/rendertargetbitmap-tips.aspx
    /// </remarks>
    public static BitmapSource RenderControl(FrameworkElement visual, int width, int height, bool isInVisualTree)
    {
    	if (!isInVisualTree)
    	{
    		// If the visual isn't part of the visual tree, then it needs to be forced to finish its layout
    		visual.Width = width;
    		visual.Height = height;
    		visual.Measure(new Size(width, height));        //  I thought these two statements would be expensive, but profiling shows it's mostly all on Render
    		visual.Arrange(new Rect(0, 0, width, height));
    	}
    
    	RenderTargetBitmap retVal = new RenderTargetBitmap(width, height, DPI, DPI, PixelFormats.Pbgra32);
    
    	DrawingVisual dv = new DrawingVisual();
    	using (DrawingContext ctx = dv.RenderOpen())
    	{
    		VisualBrush vb = new VisualBrush(visual);
    		ctx.DrawRectangle(vb, null, new Rect(new Point(0, 0), new Point(width, height)));
    	}
    
    	retVal.Render(dv);      //  profiling shows this is the biggest hit
    
    	return retVal;
    }
