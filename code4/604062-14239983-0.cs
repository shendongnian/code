    public class MyListBox : ListBox
    {
        protected override void PrepareContainerForItemOverride(
            DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            var listBoxItem = element as ListBoxItem;
            ...
        }
    }
