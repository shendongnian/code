    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        transform.Matrix = new Matrix(1d, 0d, 0d, -1d,
            sizeInfo.NewSize.Width / 2d, sizeInfo.NewSize.Height / 2d);
    }
 
