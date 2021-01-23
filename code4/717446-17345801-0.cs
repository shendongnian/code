    public static class CustomItemsBehaviour
    {
    public static readonly DependencyProperty MyTestProperty =
     DependencyProperty.RegisterAttached(
         "MyTest",
         typeof(string),
         typeof(CustomItemsBehaviour),
         new UIPropertyMetadata(""));
     public static string GetMyTest(DependencyObject itemsControl)
     {
        return (string)itemsControl.GetValue(MyTestProperty);
     }
     public static void SetMyTest(DependencyObject itemsControl, string value)
     {
        itemsControl.SetValue(MyTestProperty, value);
     }
