    private static readonly DependencyProperty CurrentItemPropertyField =
        DependencyProperty.Register/RegisterAttached(...);
    internal static DependencyProperty CurrentItemProperty
    {
        get
        {
            return CurrentItemPropertyField;
        }
    }
