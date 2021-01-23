    private FrameworkElement _frameworkElement = null;
    
    protected override void OnRender(DrawingContext dc)
    {
    	var rect = new Rect(new Point(0, 0), new Size(Width, Height));
    
    	dc.DrawImage(UtilityWPF.RenderControl(_frameworkElement, Width.ToInt_Round(), Height.ToInt_Round(), false), rect);
    }
