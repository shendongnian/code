    public static void FadeIn(this UIElement element)
    {
        element.BeginAnimation(
            UIElement.OpacityProperty,
            new DoubleAnimation(0d, 1d, TimeSpan.FromSeconds(1.5)));
    }
