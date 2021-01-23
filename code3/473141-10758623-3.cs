        public static void SetPassColor(DependencyObject obj, string passColor)
        {
            obj.SetValue(PassColorProperty, passColor);
        }
        public static string GetPassColor(DependencyObject obj)
        {
            return (string)obj.GetValue(PassColorProperty);
        }
