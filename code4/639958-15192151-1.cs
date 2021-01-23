    public static readonly DependencyProperty RowProperty = ...;
    public static void SetRow(UIElement element, int value)
    {
        element.SetValue(RowProperty, value);
    }
    public static int GetRow(UIElement element)
    {
        return (int)element.GetValue(RowProperty);
    }
