    public class MyButton : Button {
      public static readonly DependencyProperty SomeStringProperty =
        DependencyProperty.Register(
          "SomeString",
          typeof(string),
          typeof(MyButton),
          new FrameworkPropertyMetadata(string.Empty));
    
      public string SomeString {
        get {
          return (string)GetValue(SomeStringProperty);
        }
        set {
          SetValue(SomeStringProperty, value);
        }
      }
    }
