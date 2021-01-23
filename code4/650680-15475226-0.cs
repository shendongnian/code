       // Using a DependencyProperty as the backing store for AutoScrollToSelectedRow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoScrollToSelectedRowProperty =
            DependencyProperty.RegisterAttached("AutoScrollToSelectedRow", typeof(bool), typeof(DataGridTextSearch)
            , new UIPropertyMetadata(false, OnAutoScrollToSelectedRowChanged));
        public static bool GetAutoScrollToSelectedRow(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToSelectedRowProperty);
        }
        public static void SetAutoScrollToSelectedRow(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToSelectedRowProperty, value);
        }
        public static void OnAutoScrollToSelectedRowChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var datagrid = s as DataGrid;
            if (datagrid != null)
            {
                datagrid.IsSynchronizedWithCurrentItem = true;
                datagrid.EnableRowVirtualization = !((bool)e.NewValue);
                datagrid.SelectionChanged += (g, a) =>
                {
                    if (datagrid.SelectedItem != null)
                    {
                        datagrid.ScrollIntoView(datagrid.SelectedItem);
                    }
                };
            }
        }
