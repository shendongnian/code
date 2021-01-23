    public class AttachedPropertyHelper : DependencyObject
    {
        public static int GetSomething(DependencyObject obj)
        {
            return (int)obj.GetValue(SomethingProperty);
        }
        internal static void SetSomething(DependencyObject obj, int value)
        {
           obj.SetValue(SomethingPropertyKey, value);
        }
        private static readonly DependencyPropertyKey SomethingPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("Something", typeof(int), typeof(AttachedPropertyHelper), new UIPropertyMetadata(0));
      
        public static readonly DependencyProperty SomethingProperty = SomethingPropertyKey.DependencyProperty;
    }
