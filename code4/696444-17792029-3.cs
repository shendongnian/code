    public static class DataGridParameters
    {
        public static readonly DependencyProperty ShowButtonProperty = DependencyProperty.RegisterAttached("ShowButton", typeof(bool), typeof(DataGridParameters));
        public static void SetShowButton(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowButtonProperty, value);
        }
        public static bool GetShowButton(DependencyObject obj)
        {
            return (bool) obj.GetValue(ShowButtonProperty);
        }
        public static readonly DependencyProperty ButtonValueProperty = DependencyProperty.RegisterAttached("ButtonValue", typeof(object), typeof(DataGridParameters));
        public static void SetButtonValue(DependencyObject obj, object value)
        {
            obj.SetValue(ButtonValueProperty, value);
        }
        public static object GetButtonValue(DependencyObject obj)
        {
            return obj.GetValue(ButtonValueProperty);
        }
    }
 
