    public static void SetIsPaneVisible(DependenyObject target, Boolean value)
    {
        target.SetValue(IsPaneVisibleProperty, target);
    }
    public static bool GetIsPaneVisible(DependenyObject target)
    {
        return (bool)target.GetValue(IsPaneVisibleProperty);
    }
