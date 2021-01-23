    public class MyListView : ListView
        {
            protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
            {
                base.PrepareContainerForItemOverride(element, item);
                // ...
                ListViewItem listItem = element as ListViewItem;
                Binding binding = new Binding();
                binding.Mode = BindingMode.TwoWay;
                binding.Source = item;
                binding.Path = new PropertyPath("Selected");
                listItem.SetBinding(ListViewItem.IsSelectedProperty, binding);
            }
        }
