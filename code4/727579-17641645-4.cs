    public class MyDependencyClass : DependencyObject
    {
        public static readonly DependencyProperty IsEnabledColumnProperty;
        public static void SetIsEnabledColumn(DependencyObject DepObject, bool value)
        {
            DepObject.SetValue(IsEnabledColumnProperty, value);
        }
        public static bool GetIsEnabledColumn(DependencyObject DepObject)
        {
            return (bool)DepObject.GetValue(IsEnabledColumnProperty);
        }
        static MyDependencyClass()
        {
            PropertyMetadata MyPropertyMetadata = new PropertyMetadata(false);
            IsEnabledColumnProperty = DependencyProperty.RegisterAttached("IsEnabledColumn",
                                                                typeof(bool),
                                                                typeof(MyDependencyClass),
                                                                MyPropertyMetadata);
        }        
    }
