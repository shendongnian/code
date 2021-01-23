    public static void SetIsPaneVisible(DependenyObject target, Boolean value)
    {
        target.SetValue(IsPaneVisibleProperty, value);
    }
    public static bool GetIsPaneVisible(DependenyObject target)
    {
        return (bool)target.GetValue(IsPaneVisibleProperty);
    }
