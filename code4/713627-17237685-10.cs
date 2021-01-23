    public class MyCustomContentControl : ContentControl {
      public static readonly DependencyProperty MyLabelTextProperty =
        DependencyProperty.Register(
          "MyLabelText",
          typeof(string),
          typeof(MyCustomContentControl),
          new FrameworkPropertyMetadata(string.Empty));
    
      public string MyLabelText {
        get {
          return (string)GetValue(MyLabelTextProperty);
        }
        set {
          SetValue(MyLabelTextProperty, value);
        }
      }
    }
