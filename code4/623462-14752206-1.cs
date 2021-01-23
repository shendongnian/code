    [ContentProperty("LocalContent")]
    public partial class MyCanvas : Canvas
    {
        public static readonly DependencyProperty LocalContentProperty =
            DependencyProperty.Register(
                "LocalContent", 
                typeof(UIElementCollection), 
                typeof(MyCanvas ), 
                new PropertyMetadata(default(UIElementCollection)));
    }
