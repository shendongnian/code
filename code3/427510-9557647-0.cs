    public static class ListBoxItemBehavior
    {
        #region IsEnabled
        public static bool GetIsEnabled(ListBoxItem listBoxItem)
        {
            return (bool)listBoxItem.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(ListBoxItem listBoxItem, bool value)
        {
            listBoxItem.SetValue(IsEnabledProperty, value);
        }
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
            "IsEnabled",
            typeof(bool),
            typeof(ListBoxItemBehavior),
            new UIPropertyMetadata(false, OnIsEnabledChanged));
        static void OnIsEnabledChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            ListBoxItem item = depObj as ListBoxItem;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                item.MouseRightButtonDown += ItemOnMouseRightButtonDown;
            else
                item.MouseRightButtonDown -= ItemOnMouseRightButtonDown;
        }
        private static void ItemOnMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            ListBoxItem item = mouseButtonEventArgs.OriginalSource as ListBoxItem;
            if (item != null)
            {
                item.IsSelected = !item.IsSelected;
            }
        }
        #endregion
    }
