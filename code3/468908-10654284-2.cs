    public class AttachedPropertyHelper : DependencyObject
    {
        public static int GetSomething(DependencyObject obj)
        {
            return (int)obj.GetValue(SomethingProperty);
        }
        public static void SetSomething(DependencyObject obj, int value)
        {
            obj.SetValue(SomethingProperty, value);
        }
        // Using a DependencyProperty as the backing store for Something. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SomethingProperty =
            DependencyProperty.RegisterAttached("Something", typeof(int), typeof(AttachedPropertyHelper), new UIPropertyMetadata(0));
    }
