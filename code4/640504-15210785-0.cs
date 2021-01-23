    public static class TreeViewBehavior
    {
        public static readonly DependencyProperty SelectionChangedActionProperty =
            DependencyProperty.RegisterAttached("SelectionChangedAction", typeof (Action<object>), typeof (TreeViewBehavior), new PropertyMetadata(default(Action), OnSelectionChangedActionChanged));
        private static void OnSelectionChangedActionChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var treeView = sender as TreeView;
            if (treeView == null) return;
            var action = GetSelectionChangedAction(treeView);
            if (action != null)
            {
                // Remove the next line if you don't want to invoke immediately.
                InvokeSelectionChangedAction(treeView);
                treeView.SelectedItemChanged += TreeViewOnSelectedItemChanged;
            }
            else
            {
                treeView.SelectedItemChanged -= TreeViewOnSelectedItemChanged;
            }
        }
        private static void TreeViewOnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var treeView = sender as TreeView;
            if (treeView == null) return;
            InvokeSelectionChangedAction(treeView);
        }
        private static void InvokeSelectionChangedAction(TreeView treeView)
        {
            var action = GetSelectionChangedAction(treeView);
            if (action == null) return;
            var selectedItem = treeView.GetValue(TreeView.SelectedItemProperty);
            action(selectedItem);
        }
        public static void SetSelectionChangedAction(TreeView treeView, Action<object> value)
        {
            treeView.SetValue(SelectionChangedActionProperty, value);
        }
        public static Action<object> GetSelectionChangedAction(TreeView treeView)
        {
            return (Action<object>) treeView.GetValue(SelectionChangedActionProperty);
        }
    }
