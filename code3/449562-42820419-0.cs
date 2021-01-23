    public class SelectingItemAttachedProperty
    {
        public static readonly DependencyProperty SelectingItemProperty = DependencyProperty.RegisterAttached(
            "SelectingItem",
            typeof(int),
            typeof(SelectingItemAttachedProperty),
            new PropertyMetadata(default(int), OnSelectingItemChanged));
        public static int GetSelectingItem(DependencyObject target)
        {
            return (int)target.GetValue(SelectingItemProperty);
        }
        public static void SetSelectingItem(DependencyObject target, int value)
        {
            target.SetValue(SelectingItemProperty, value);
        }
        static void OnSelectingItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var lb = sender as ListBox;
            if (lb?.SelectedItem == null)
                return;
            lb.Dispatcher.InvokeAsync(() =>
            {
                lb.UpdateLayout();
                lb.ScrollIntoView(lb.SelectedItem);
            });
        }
    }
