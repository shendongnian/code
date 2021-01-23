    public class AnimatedSwitch : DependencyObject
    {
        // Define the attached properties      
        public static DependencyProperty BindingProperty =
            DependencyProperty.RegisterAttached("Binding", typeof(object), typeof(AnimatedSwitch),
            new PropertyMetadata(BindingChanged));
        public static DependencyProperty PropertyProperty =
            DependencyProperty.RegisterAttached("Property", typeof(string), typeof(AnimatedSwitch));
        public static object GetBinding(DependencyObject e)
        {
            return e.GetValue(BindingProperty);
        }
        public static void SetBinding(DependencyObject e, object value)
        {
            e.SetValue(BindingProperty, value);
        }
        public static string GetProperty(DependencyObject e)
        {
            return (string)e.GetValue(PropertyProperty);
        }
        public static void SetProperty(DependencyObject e, string value)
        {
            e.SetValue(PropertyProperty, value);
        }
        // When the value changes do the fadeout-switch-fadein      
        private static void BindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Storyboard fadeout = new Storyboard();
            var fadeoutAnim = new DoubleAnimation() { To = 0, Duration = new Duration(TimeSpan.FromSeconds(0.3)) };
            Storyboard.SetTarget(fadeoutAnim, d);
            Storyboard.SetTargetProperty(fadeoutAnim, new PropertyPath("Opacity"));
            fadeout.Children.Add(fadeoutAnim);
            fadeout.Completed += (d1, d2) =>
            {
                var propName = GetProperty(d);
                if (propName != null)
                {
                    var prop = d.GetType().GetProperty(propName);
                    var binding = GetBinding(d);
                    prop.SetValue(d, binding, null);
                }
                Storyboard fadein = new Storyboard();
                var fadeinAnim = new DoubleAnimation() { To = 1, Duration = new Duration(TimeSpan.FromSeconds(0.3)) };
                Storyboard.SetTarget(fadeinAnim, d);
                Storyboard.SetTargetProperty(fadeinAnim, new PropertyPath("Opacity"));
                fadein.Children.Add(fadeinAnim);
                fadein.Begin();
                
            };
            fadeout.Begin();
        }
    }
