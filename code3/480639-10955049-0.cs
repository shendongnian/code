    public class Prop : DependencyObject
    {
        public static readonly DependencyProperty IDProperty =
            DependencyProperty.RegisterAttached("ID", typeof(string), typeof(Prop), new PropertyMetadata(null));
        public static void SetID(UIElement element, string value)
        {
            element.SetValue(IDProperty, value);
        }
        public static string GetID(UIElement element)
        {
            return (string)element.GetValue(IDProperty);
        }
    }
