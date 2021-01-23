            public static bool GetStopAnimating(DependencyObject obj)
            {
                return (bool)obj.GetValue(StopAnimatingProperty);
            }
            public static void SetStopAnimating(DependencyObject obj, bool value)
            {
                obj.SetValue(StopAnimatingProperty, value);
            }
            // Using a DependencyProperty as the backing store for StopAnimating.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty StopAnimatingProperty =
                DependencyProperty.RegisterAttached("StopAnimating", typeof(bool), typeof(ShakeBehavior), new UIPropertyMetadata(true));
