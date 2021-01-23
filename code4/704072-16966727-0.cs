    public class MyDependencyClass : DependencyObject
    {
        public static readonly DependencyProperty IsSelectedProperty;
        public static void SetIsSelected(DependencyObject DepObject, Boolean value)
        {
            DepObject.SetValue(IsSelectedProperty, value);
        }
        public static Boolean GetIsSelected(DependencyObject DepObject)
        {
            return (Boolean)DepObject.GetValue(IsSelectedProperty);
        }
        private static bool IsSelectedValid(object Value)
        {
            if (Value.GetType() == typeof(bool))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static MyDependencyClass()
        {
            FrameworkPropertyMetadata MetaData = new FrameworkPropertyMetadata((Boolean)false);
            IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected",
                                                                typeof(Boolean),
                                                                typeof(MyDependencyClass),
                                                                MetaData,
                                                                new ValidateValueCallback(IsSelectedValid));
        }
    }
