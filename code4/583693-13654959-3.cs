    private static void MouseMoveEventHandler(RoutedEventArgs e)
    {
        // The size of the crop is always the same
        // but the portion of the picture different.
        SrcRectangleLeft = new Int32Rect(SrcRectangleLeft.X + mouseDelta.X, 
            SrcRectangleLeft.Y + mouseDelta.Y,
            SrcRectangleLeft.Width, SrcRectangleLeft.Height);
    }
