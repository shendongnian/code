    foreach (var item in lvList.Items)
    {
        var listItem = lvList.ItemContainerGenerator
            .ContainerFromItem(item) as ListViewItem;
        CheckBox cb = GetVisualDescendantByName(listItem, "checkbox") as CheckBox;
        // Do stuff with CheckBox...
        var myVar = cb.IsChecked;
    }
