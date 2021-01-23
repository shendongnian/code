    protected override void OnRender(DrawingContext drawingContext)
    {
        BitmapImage_Left.SourceRect = SrcRectangleLeft;
        drawingContext.DrawImage(BitmapImage_Left, Window_LeftHalf);
        BitmapImage_Right.SourceRect = SrcRectangleRight;
        drawingContext.DrawImage(BitmapImage_Right, Window_RightHalf);
    }
