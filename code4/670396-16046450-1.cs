    public class ShadowButton : Button
    {
        public DependencyProperty IsDropShadowVisibleProperty =
            DependencyProperty.Register("IsDropShadowVisible", typeof(Boolean), typeof(ShadowButton), new PropertyMetadata(false));
        public Boolean IsDropShadowVisible
        {
            get { return (Boolean)GetValue(IsDropShadowVisibleProperty); }
            set { SetValue(IsDropShadowVisibleProperty, value); }
        }
    }
