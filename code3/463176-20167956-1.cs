    public class MyListView : ListView
    {
        public event RightTappedEventHandler ItemRightTapped;
        protected override DependencyObject GetContainerForItemOverride()
        {
            var item = new MyListViewItem();
            item.RightTapped += OnItemRightTapped;
            return item;
        }
        protected virtual void OnItemRightTapped(object sender, RightTappedRoutedEventArgs args)
        {
            if (ItemRightTapped != null)
                ItemRightTapped(sender, args);
            args.Handled = true;
        }
    }
    public class MyListViewItem : ListViewItem
    {
        protected override void OnRightTapped(RightTappedRoutedEventArgs e)
        {
            base.OnRightTapped(e);
            // Stop 'swallowing' the event
            e.Handled = false;
        }
    }
