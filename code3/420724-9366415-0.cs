    public class MyCustomIdSource
    {
        public static readonly DependencyProperty MyCustomIdProperty = 
            DependencyProperty.RegisterAttached("MyCustomId", typeof(Int32), typeof(MyCustomIdSource));
        public static void SetMyCustomId(UIElement element, Int32 value)
        {
            element.SetValue(MyCustomIdProperty, value);
        }
        public static Int32 GetMyCustomId(UIElement element)
        {
            return (Int32)element.GetValue(MyCustomIdProperty);
        }
    }
