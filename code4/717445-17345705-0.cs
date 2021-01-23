    public static readonly DependencyProperty MyTestProperty =
     DependencyProperty.RegisterAttached(
         "MyTest",
         typeof(string),
         typeof(CustomItemsBehaviour),
         new UIPropertyMetadata(""));
     
