        public static bool GetIsParentWindowActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsParentWindowActiveProperty);
        }
        public static void SetIsParentWindowActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsParentWindowActiveProperty, value);
        }
        public static readonly DependencyProperty IsParentWindowActiveProperty = DependencyProperty.RegisterAttached(
            "IsParentWindowActive", 
            typeof(bool), 
            typeof(FocusedCellBehavior), 
            new UIPropertyMetadata(false));
