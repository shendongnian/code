    public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
    {
        double scaleFactor = GetCurrentScaleFactor(this._parent);
    
        if (this._visualChildren != null)
        {
            foreach (var thumb in this._visualChildren.OfType<Thumb>())
            {
                thumb.RenderTransform 
                    = new ScaleTransform(1 / scaleFactor , 1 / scaleFactor );
                thumb.RenderTransformOrigin = new Point(0.5, 0.5);
            }
        }
    
        return base.GetDesiredTransform(transform);
    }
