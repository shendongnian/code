    public class MyListBox : ListBox
    {
        protected override void PrepareContainerForItemOverride(
            DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            if (item is Item)
            {
                var binding = new Binding
                {
                    Source = item,
                    Path = new PropertyPath("IsSelected"),
                    Mode = BindingMode.TwoWay
                };
                ((ListBoxItem)element).SetBinding(ListBoxItem.IsSelectedProperty, binding);
            }
        }
    }
