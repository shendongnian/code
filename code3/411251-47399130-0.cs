    public static class FrameworkElementHelper
    {
        public static void RemoveFromParent(this FrameworkElement item)
        {
            if (item != null)
            {
                var parentItemsControl = (ItemsControl)item.Parent;
                if (parentItemsControl != null)
                {
                    parentItemsControl.Items.Remove(item as UIElement);
                }
            }
        }
    }
