    public class MyLabelPropertyClass {
      public static readonly DependencyProperty MyLabelTextProperty =
        DependencyProperty.RegisterAttached(
          "MyLabelText",
          typeof(string),
          typeof(MyLabelPropertyClass),
          new FrameworkPropertyMetadata(
            string.Empty, FrameworkPropertyMetadataOptions.Inherits));
    
      public static void SetMyLabelText(UIElement element, string value) {
        element.SetValue(MyLabelTextProperty, value);
      }
    
      public static string GetMyLabelText(UIElement element) {
        return (string)element.GetValue(MyLabelTextProperty);
      }
    }
