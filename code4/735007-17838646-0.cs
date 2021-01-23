    public static readonly DependencyProperty DragPositionProperty =
        DependencyProperty.RegisterAttached(
            "DragPosition", typeof(Point), typeof(LogViewHeaderPanel),
            new FrameworkPropertyMetadata(
                new Point(), FrameworkPropertyMetadataOptions.AffectsParentArrange));
