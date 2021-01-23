    public class TreeViewSelectedItemProperty
    {
        public static readonly DependencyProperty IsSelectedItemBoundProperty =
            DependencyProperty.RegisterAttached("IsSelectedItemBound", typeof (bool),
                                                typeof (TreeViewSelectedItemProperty),
                                                new PropertyMetadata(OnIsSelectedItemBoundChanged));
        public static bool GetIsSelectedItemBound(DependencyObject target)
        {
            return (bool) target.GetValue(IsSelectedItemBoundProperty);
        }
        public static void SetIsSelectedItemBound(DependencyObject target, bool value)
        {
            target.SetValue(IsSelectedItemBoundProperty, value);
        }
        private static void OnIsSelectedItemBoundChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue) 
                ((TreeView) sender).SelectedItemChanged += OnTreeViewSelectedItemChanged;
            else 
                ((TreeView) sender).SelectedItemChanged -= OnTreeViewSelectedItemChanged;
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached("SelectedItem", typeof (object), typeof (TreeViewSelectedItemProperty),
                                                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                              OnSelectedItemChanged));
        public static object GetSelectedItem(DependencyObject target)
        {
            return target.GetValue(SelectedItemProperty);
        }
        public static void SetSelectedItem(DependencyObject target, object value)
        {
            target.SetValue(SelectedItemProperty, value);
        }
        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var treeView = sender as TreeView;
            if (treeView == null) 
                return;
            if (treeView.SelectedItem == e.NewValue)
                return;
            var tvi = GetTreeViewItem(treeView, e.NewValue);
            if (tvi == null)
                return;
            tvi.SetValue(TreeViewItem.IsSelectedProperty, true);
        }
        private static void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetSelectedItem((TreeView) sender, e.NewValue);
        }
        private static TreeViewItem GetTreeViewItem(ItemsControl container, object item)
        {
            if (container == null) 
                return null;
            if (container.DataContext == item)
                return container as TreeViewItem;
            container.ApplyTemplate();
            var childItemsPresenter =
                (ItemsPresenter) container.Template.FindName("ItemsHost", container);
            if (childItemsPresenter != null)
            {
                childItemsPresenter.ApplyTemplate();
            }
            else
            {
                childItemsPresenter = FindChildItemsPresenter(container);
                if (childItemsPresenter == null)
                {
                    container.UpdateLayout();
                    childItemsPresenter = FindChildItemsPresenter(container);
                }
            }
            var itemsHostPanel = (Panel) VisualTreeHelper.GetChild(childItemsPresenter, 0);
            
            //Ensure panel's Generator is initialised
            var children = itemsHostPanel.Children;
            for (int i = 0, count = container.Items.Count; i < count; i++)
            {
                var subContainer = (TreeViewItem) container.ItemContainerGenerator.ContainerFromIndex(i);
                var resultContainer = GetTreeViewItem(subContainer, item);
                if (resultContainer == null) 
                    continue;
                resultContainer.BringIntoView();
                return resultContainer;
            }
            return null;
        }
        private static ItemsPresenter FindChildItemsPresenter(DependencyObject dependencyObject)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = (Visual)VisualTreeHelper.GetChild(dependencyObject, i);
                if (child == null) 
                    continue;
                var childItemsPresenter = child as ItemsPresenter;
                if (childItemsPresenter != null)
                    return childItemsPresenter;
                childItemsPresenter = FindChildItemsPresenter(child);
                if (childItemsPresenter != null)
                    return childItemsPresenter;
            }
            return null;
        }
    }
