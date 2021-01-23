    public static readonly DependencyProperty FormatSegment1Property = DependencyProperty.RegisterAttached(
            "FormatSegment1", typeof(string), typeof(LocTextExtension), new PropertyMetadata(default(string)));
    public static void SetFormatSegment1(DependencyObject element, string value)
    {
        element.SetValue(FormatSegment1Property, value);
    }
    public static string GetFormatSegment1(DependencyObject element)
    {
        return (string)element.GetValue(FormatSegment1Property);
    }
.
    <Window Title="{lex:LocText MyApp:Resources:windowTitle}" lex:LocText.FormatSegment1="{Binding Version}" />
