    public sealed class Solution
    {
        public static readonly DependencyProperty IsReleaseBuildProperty =
            DependencyProperty.RegisterAttached(
            "IsReleaseBuild",
            typeof(bool),
            typeof(Solution),
            new FrameworkPropertyMetadata(
    #if DEBUG
                false
    #else
                true
    #endif
               ));
        public static bool GetIsReleaseBuild(DependencyObject source)
        {
            return (bool)source.GetValue(IsReleaseBuildProperty);
        }
    }
