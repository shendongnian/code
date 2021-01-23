    public static class ThemeProperties
    {
        public static object GetSelectedValue(DependencyObject obj)
        {
            return (object)obj.GetValue(SelectedValueProperty);
        }
        public static void SetSelectedValue(DependencyObject obj, object value)
        {
            obj.SetValue(SelectedValueProperty, value);
        }
        
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.RegisterAttached("SelectedValue", typeof(object), 
              typeof(ThemeProperties), new FrameworkPropertyMetadata(null, 
               FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));     
    }
