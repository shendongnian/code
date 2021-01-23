    namespace MyNamespace.Controls
    {
        public partial class MyItemsControl : ItemsControl
        {
            public static readonly DependencyProperty MyOrientationProperty =
                DependencyProperty.Register(
                "MyOrientation",
                typeof(Orientation),
                typeof(MyItemsControl));
    
            public Orientation MyOrientation
            {
                get { return (Orientation)GetValue(MyOrientationProperty); }
                set { SetValue(MyOrientationProperty, value); }
            }
        }
    }
