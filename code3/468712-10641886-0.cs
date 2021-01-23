    public void ExpandSubtree()
    {
        ExpandRecursive(this);
    }
    private static void ExpandRecursive(TreeViewItem item)
    {
        if (item != null)
        {
            if (!item.IsExpanded)
            {
                item.SetCurrentValueInternal(IsExpandedProperty, BooleanBoxes.TrueBox);
            }
            item.ApplyTemplate();
            ItemsPresenter presenter = (ItemsPresenter) item.Template.FindName("ItemsHost", item);
            if (presenter != null)
            {
                presenter.ApplyTemplate();
            }
            else
            {
                item.UpdateLayout();
            }
            VirtualizingPanel itemsHost = item.ItemsHost as VirtualizingPanel;
            item.ItemsHost.EnsureGenerator();
            int index = 0;
            int count = item.Items.Count;
            while (index < count)
            {
                TreeViewItem item2;
                if (itemsHost != null)
                {
                    itemsHost.BringIndexIntoView(index);
                    item2 = (TreeViewItem) item.ItemContainerGenerator.ContainerFromIndex(index);
                }
                else
                {
                    item2 = (TreeViewItem) item.ItemContainerGenerator.ContainerFromIndex(index);
                    item2.BringIntoView();
                }
                if (item2 != null)
                {
                    ExpandRecursive(item2);
                }
                index++;
            }
        }
    }
