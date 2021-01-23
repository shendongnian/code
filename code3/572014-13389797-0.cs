    public MainWindow()
    {
    	inkCanvas.Strokes.StrokesChanged += Strokes_StrokesChanged;
    }
    
    private void Strokes_StrokesChanged(object sender, StrokeCollectionChangedEventArgs e)
    {
    	// Mark dirty
    	foreach (Stroke stroke in e.Added)
    	{
    		stroke.StylusPointsChanged += stroke_StylusPointsChanged;
    	}
    	foreach (Stroke stroke in e.Removed)
    	{
    		stroke.StylusPointsChanged -= stroke_StylusPointsChanged;
    	}
    }
    
    private void stroke_StylusPointsChanged(object sender, System.EventArgs e)
    {
    	// Mark dirty
    }
