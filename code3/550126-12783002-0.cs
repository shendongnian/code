    protected override void OnRender(DrawingContext drawingContext)
    {
        try
        {
            drawingContext.PushClip(whatever);
            OnRenderInternal(...);        
        }
        finally
        {
            drawingContext.Pop();
        }
    }
