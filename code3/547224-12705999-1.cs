        public static bool GetHasFocusedCell(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasFocusedCellProperty);
        }
        public static void SetHasFocusedCell(DependencyObject obj, bool value)
        {
            obj.SetValue(HasFocusedCellProperty, value);
        }
        public static readonly DependencyProperty HasFocusedCellProperty = DependencyProperty.RegisterAttached(
            "HasFocusedCell",
            typeof(bool), 
            typeof(FocusedCellBehavior),
            new UIPropertyMetadata(false));
