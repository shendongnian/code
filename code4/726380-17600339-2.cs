    public class MyCustomPropertyCollection {
      public static readonly DependencyProperty SomeStringProperty =
        DependencyProperty.RegisterAttached(
          "SomeString",
          typeof(string),
          typeof(MyCustomPropertyCollection),
          new FrameworkPropertyMetadata(string.Empty));
    
      public static void SetSomeString(UIElement element, string value) {
        element.SetValue(SomeStringProperty, value);
      }
    
      public static string GetSomeString(UIElement element) {
        return (string)element.GetValue(SomeStringProperty);
      }
    }
Style.DataTrigger
    <DataTrigger Binding="{Binding Path=(local:MyCustomPropertyCollection.SomeString),
                                    RelativeSource={RelativeSource Self}}"
                  Value="{x:Static sys:String.Empty}">
      ...
    </DataTrigger>
