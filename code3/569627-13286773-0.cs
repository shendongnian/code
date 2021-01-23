    class MayClass
    {
        public static readonly DependencyProperty SomethingProperty =
            DependencyProperty.RegisterAttached(
               "Something", typeof(object), typeof(MyClass));
        // required
        public static object GetSomething(UIElement element)
        {
            return element.GetValue(SomethingProperty );
        }
        // required
        public static void SetSomething(UIElement element, object value)
        {
            element.SetValue(SomethingProperty , value);
        }
    }
