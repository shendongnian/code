    public class BuggyTextBlock : TextBlock
    {
        static BuggyTextBlock()
        {
            TextProperty.OverrideMetadata(typeof(BuggyTextBlock),
                          new FrameworkPropertyMetadata((PropertyChangedCallback)null,
                                                        CoerceText));
        }
        private static object CoerceText(DependencyObject sender, object value)
        {
            // 1. value == blubb
            // 2. value == new blubb
            // and here it comes i don't know why but it get called 3 Times
            // 3. value == Hello WorldHello World <-- FatalExecutionEngineError here
            BuggyTextBlock tb = (BuggyTextBlock)sender; 
            tb.Inlines.Add(new Run("Hello World")); // FatalExecutionEngineError here
            return string.Empty;
        }
    }
