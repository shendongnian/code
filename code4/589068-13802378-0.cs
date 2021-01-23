    public static void SetIsPaneVisible(DependenyObject target, Boolean value)
    {
        element.SetValue(IsIsPaneVisible, target);
    }
    public static bool GetIsPaneVisible(DependenyObject target)
    {
        return (bool)target.GetValue(IsPaneVisible);
    }
