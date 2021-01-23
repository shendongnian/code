    public class DepClass : DependencyObject
    {
        public static readonly DependencyProperty CurrentStatusProperty;
        public static void SetCurrentStatus(DependencyObject DepObject, int value)
        {
            DepObject.SetValue(CurrentStatusProperty, value);
        }
        public static int GetCurrentStatus(DependencyObject DepObject)
        {
            return (int)DepObject.GetValue(CurrentStatusProperty);
        }
        static DepClass()
        {
            PropertyMetadata MyPropertyMetadata = new PropertyMetadata(0);
            CurrentStatusProperty = DependencyProperty.RegisterAttached("CurrentStatus",
                                                                typeof(int),
                                                                typeof(DepClass),
                                                                MyPropertyMetadata);
        }        
    }
