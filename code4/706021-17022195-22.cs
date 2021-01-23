    public static class ContextHelp
    {
        public static readonly DependencyProperty KeywordProperty =
            DependencyProperty.RegisterAttached(
                "Keyword",
                typeof(string),
                typeof(ContextHelp));
        public static void SetKeyword(UIElement target, string value)
        {
            target.SetValue(KeywordProperty, value);
        }
        public static string GetKeyword(UIElement target)
        {
            return (string)target.GetValue(KeywordProperty);
        }
    }
