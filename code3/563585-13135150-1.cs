    class MyClass
    {
        public static readonly DependencyProperty IsEditingNumberProperty =
            DependencyProperty.Register(
                "IsEditingNumber", typeof(bool), typeof(MyClass), ...);
    }
