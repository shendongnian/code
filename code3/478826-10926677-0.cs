    private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Color accent = ColorHelper.PhoneAccentColor;
        Color accentDark = ColorHelper.DarkPhoneAccentColor;
        foreach (object item in e.RemovedItems)
            SetListBoxItemColor(item, accentDark);
        foreach (object item in e.AddedItems)
            SetListBoxItemColor(item, accent);
    }
    private void SetListBoxItemColor(object item, Color color)
    {
        ListBoxItem listBoxItem = listBox.ItemContainerGenerator
            .ContainerFromItem(item) as ListBoxItem;
        if (listBoxItem != null)
        {
            Rectangle rectangle = GetItemsRecursive<Rectangle>(
                listBoxItem, "listItemSideBar");
            SolidColorBrush fillBrush = new SolidColorBrush();
            fillBrush.Color = color;
            rectangle.Fill = fillBrush;
        }
    }
    private T GetItemsRecursive<T>(DependencyObject lb, string name)
        where T : DependencyObject
    {
        int childrenCount = VisualTreeHelper.GetChildrenCount(lb);
        for (int i = 0; i < childrenCount; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(lb, i);
            if (child is T)
            {
                string childName = child.GetType().PropertyValue<string>(child, "Name");
                if (String.Compare(childName, name) == 0)
                    return (T)child;
            }
            return GetItemsRecursive<T>(child, name);
        }
        return default(T);
    }
