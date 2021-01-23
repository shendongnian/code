        //assumes using a ListView
        var item = (ListViewItem)listView.ItemContainerGenerator.ContainerFromItem(myModel);
    
        // traverse children
        var image = GetChildOfType<Image>(item);
        // use the image!
    
    private T GetChildOfType<T>(DependencyObject obj)
    {
        for(int i = 0; i< VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            var child = VisualTreeHelper.GetChild(obj, i);
            if(child is T) return child as T;
            
            T item = GetChildOfType<T>(child);
            if(item != null) return item;
        }
        return null;
    }
