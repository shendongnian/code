    private static void MouseMoveEventHandler(RoutedEventArgs e)
    {
        // The size of the crop is always the same
        // but the portion of the picture different.
        SrcRectangleLeft.Position.X += mouseDelta.X
        SrcRectangleLeft.Position.Y += mouseDelta.Y
    }
