    public class ItemsControlScrollToSelectedBehavior : Behavior<ItemsControl>
    {
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(ItemsControlScrollToSelectedBehavior),
                new FrameworkPropertyMetadata(null,
                    new PropertyChangedCallback(OnSelectedItemsChanged)));
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ItemsControlScrollToSelectedBehavior target = (ItemsControlScrollToSelectedBehavior)d;
            object oldSelectedItems = e.OldValue;
            object newSelectedItems = target.SelectedItem;
            target.OnSelectedItemsChanged(oldSelectedItems, newSelectedItems);
        }
        protected virtual void OnSelectedItemsChanged(object oldSelectedItems, object newSelectedItems)
        {
            try
            {
                var sv = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(AssociatedObject, 0), 0) as ScrollViewer;
                // now get the index of the item your passing in
                int index = AssociatedObject.Items.IndexOf(newSelectedItems);
                if (index != -1)
                {
                    sv?.ScrollToVerticalOffset(index);
                }
            }
            catch
            {
                // Ignore
            }
        }
    }
