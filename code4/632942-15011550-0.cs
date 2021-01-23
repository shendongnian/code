    /// <summary>
    /// Exposes attached behaviors that can be
    /// applied to DataGridRow objects.
    /// </summary>
    public static class DataGridRowBehavior
    {
        #region IsBroughtIntoViewWhenSelected
        public static bool GetIsBroughtIntoViewWhenSelected(DataGridRow dataGridRow)
        {
            return (bool)dataGridRow.GetValue(IsBroughtIntoViewWhenSelectedProperty);
        }
        public static void SetIsBroughtIntoViewWhenSelected(
          DataGridRow dataGridRow, bool value)
        {
            dataGridRow.SetValue(IsBroughtIntoViewWhenSelectedProperty, value);
        }
        public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty =
            DependencyProperty.RegisterAttached(
            "IsBroughtIntoViewWhenSelected",
            typeof(bool),
            typeof(DataGridRowBehavior),
            new UIPropertyMetadata(false, OnIsBroughtIntoViewWhenSelectedChanged));
        static void OnIsBroughtIntoViewWhenSelectedChanged(
          DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            DataGridRow item = depObj as DataGridRow;
            if (item == null)
                return;
            if (e.NewValue is bool == false)
                return;
            if ((bool)e.NewValue)
                item.Selected += OnDataGridRowSelected;
            else
                item.Selected -= OnDataGridRowSelected;
        }
        static void OnDataGridRowSelected(object sender, RoutedEventArgs e)
        {
            // Only react to the Selected event raised by the TreeViewItem
            // whose IsSelected property was modified. Ignore all ancestors
            // who are merely reporting that a descendant's Selected fired.
            if (!Object.ReferenceEquals(sender, e.OriginalSource))
                return;
            DataGridRow item = e.OriginalSource as DataGridRow;
            if (item != null)
                item.BringIntoView();
        }
        #endregion // IsBroughtIntoViewWhenSelected
    }
