    public class SynchronisedScroll
    {
        public static SynchronisedScrollToken GetToken(ScrollViewer obj)
        {
            return (SynchronisedScrollToken)obj.GetValue(TokenProperty);
        }
        public static void SetToken(ScrollViewer obj, SynchronisedScrollToken value)
        {
            obj.SetValue(TokenProperty, value);
        }
        public static readonly DependencyProperty TokenProperty =
            DependencyProperty.RegisterAttached("Token", typeof(SynchronisedScrollToken), typeof(SynchronisedScroll), new PropertyMetadata(TokenChanged));
        private static void TokenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scroll = d as ScrollViewer;
            var oldToken = e.OldValue as SynchronisedScrollToken;
            var newToken = e.NewValue as SynchronisedScrollToken;
            if (scroll != null)
            {
                oldToken?.unregister(scroll);
                newToken?.register(scroll);
            }
        }
    }
