        private void CollapseAll(ItemsControl Items, bool Collapse)
        {
            foreach (object obj in Items.Items)
            {
                ItemsControl ChildControl = Items.ItemContainerGenerator.ContainerFromItem(obj) as ItemsControl;
                if (ChildControl != null)
                {
                    CollapseAll(ChildControl, Collapse);
                }
                TreeViewItem Item = ChildControl as TreeViewItem;
                if (Item != null) Item.IsExpanded = false;
            }
        }
        private void treeView1_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem CurrentItem = (TreeViewItem)treeView1.SelectedItem;
            if (CurrentItem == null) return;
            if (!(CurrentItem.Parent is TreeViewItem)) return;
            TreeViewItem Parent = (TreeViewItem)CurrentItem.Parent;
            if (Parent == null) return;
            foreach (TreeViewItem TreeViewItem in Parent.Items)
            {
                if (TreeViewItem != CurrentItem)
                {
                    CollapseAll(TreeViewItem, true);
                    TreeViewItem.IsExpanded = false;
                }
            }
        }
    }
