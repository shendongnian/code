        public static void SetPassColor(DependencyObject obj, bool isPreviewButton)
        {
            obj.SetValue(PassColorProperty, isPreviewButton);
        }
        public static bool GetPassColor(DependencyObject obj)
        {
            return (bool)obj.GetValue(PassColorProperty);
        }
