    protected override Size MeasureOverride(Size availableSize)
    {
        double x = 0, y = 0;
        foreach (UIElement child in Children)
        {
            TransformGroup transformGroup = child.RenderTransform as TransformGroup;
            if (transformGroup == null)
            {
                TranslateTransform translatationTransform = new TranslateTransform();
                transformGroup = new TransformGroup();
                transformGroup.Children.Add(translatationTransform);
                child.RenderTransform = transformGroup;
                child.RenderTransformOrigin = new Point(0, 0);
            }
            child.Measure(availableSize);
            x = Math.Max(x, availableSize.Width == double.PositiveInfinity ? child.DesiredSize.Width : availableSize.Width);
            y += child.DesiredSize.Height;
        }
        return new Size(
            availableSize.Width == double.PositiveInfinity ? x : availableSize.Width,
            availableSize.Height == double.PositiveInfinity ? y : availableSize.Height);
    }
