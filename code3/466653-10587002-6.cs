    protected override void OnInvalidated(InvalidateEventArgs e)
    {
        base.OnInvalidated(e);
        if (mtexture != null)
        {
            mtexture.Dispose();
            mtexture = null;
        }
        mtexture = new Bitmap(Width, Height);
        Draw(mRotorAngle);
    }
