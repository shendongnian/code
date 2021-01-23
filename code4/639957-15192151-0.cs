    public static readonly DependencyProperty RowProperty = ...;
    public static void SetRow(UIElement element, int value)
    {
        element.SetValue(IsBubbleSourceProperty, value);
    }
    public static int GetIsBubbleSource(UIElement element)
    {
        return (int)element.GetValue(RowProperty);
    }
