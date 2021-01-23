    public class Class1 : Control {
      public Class1() {
        this.DefaultStyleKey = typeof(Class1);
      }
      public object Content1 {
        get { return GetValue(Content1Property); }
        set { SetValue(Content1Property, value); }
      }
      // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty Content1Property =
          DependencyProperty.Register("Content1", typeof(object), typeof(Class1), null);
      public object Content2 {
        get { return GetValue(Content2Property); }
        set { SetValue(Content2Property, value); }
      }
      // Using a DependencyProperty as the backing store for Content2.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty Content2Property =
          DependencyProperty.Register("Content2", typeof(object), typeof(Class1), null);
      public object Content3 {
        get { return GetValue(Content3Property); }
        set { SetValue(Content3Property, value); }
      }
      // Using a DependencyProperty as the backing store for Content3.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty Content3Property =
          DependencyProperty.Register("Content3", typeof(object), typeof(Class1), null);
    }
