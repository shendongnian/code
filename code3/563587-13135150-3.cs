    public class MyClass : DependencyObject
    {
        public static readonly DependencyProperty IsEditingNumberProperty =
            DependencyProperty.Register(
                "IsEditingNumber", typeof(bool), typeof(MyClass), ...);
 
        // CLR wrapper
        public bool IsEditingNumber
        {
            get { return (bool)GetValue(IsEditingNumberProperty); }
            set { SetValue(IsEditingNumberProperty, value); }
        }
    }
