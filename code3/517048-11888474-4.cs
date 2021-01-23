    public static void SkewAnimation(this UIElement element)
    {
        ((SkewTransform)element.RenderTransform).BeginAnimation(
            SkewTransform.AngleXProperty,
            new DoubleAnimation(0d, 360d, TimeSpan.FromSeconds(3d)));
    }
