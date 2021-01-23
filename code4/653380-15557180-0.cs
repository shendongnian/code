    public static class IndexAttachedProperty
    {
        #region TabItemIndex
        public static int GetTabItemIndex(DependencyObject obj)
        {
            return (int) obj.GetValue(TabItemIndexProperty);
        }
        public static void SetTabItemIndex(DependencyObject obj, int value)
        {
            obj.SetValue(TabItemIndexProperty, value);
        }
        // Using a DependencyProperty as the backing store for TabItemIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TabItemIndexProperty =
            DependencyProperty.RegisterAttached("TabItemIndex", typeof (int), typeof (IndexAttachedProperty),
                                                new PropertyMetadata(-1));
        #endregion
        #region TrackTabItemIndex
        public static bool GetTrackTabItemIndex(DependencyObject obj)
        {
            return (bool) obj.GetValue(TrackTabItemIndexProperty);
        }
        public static void SetTrackTabItemIndex(DependencyObject obj, bool value)
        {
            obj.SetValue(TrackTabItemIndexProperty, value);
        }
        // Using a DependencyProperty as the backing store for TrackTabItemIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TrackTabItemIndexProperty =
            DependencyProperty.RegisterAttached("TrackTabItemIndex", typeof (bool), typeof (IndexAttachedProperty),
                                                new PropertyMetadata(false, TrackTabItemIndexOnPropertyChanged));
        private static void TrackTabItemIndexOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var tabControl = GetParent(d, p => p is TabControl) as TabControl;
            var tabItem = GetParent(d, p => p is TabItem) as TabItem;
            if (tabControl == null || tabItem == null)
                return;
            if (!(bool)e.NewValue)
                return;
            int index = tabControl.Items.IndexOf(tabItem.DataContext == null ? tabItem : tabItem.DataContext);
            SetTabItemIndex(d, index);
        }
        #endregion
        
        public static DependencyObject GetParent(DependencyObject item, Func<DependencyObject, bool> condition)
        {
            if (item == null)
                return null;
            return condition(item) ? item : GetParent(VisualTreeHelper.GetParent(item), condition);
        }
    }
