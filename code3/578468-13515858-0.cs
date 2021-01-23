    private void ModifyListViewBackground(int i, Brush brush)  
        {  
            listView.ItemContainerGenerator.StatusChanged -=StatusChangedCompleted;
            listView.ItemContainerGenerator.StatusChanged +=StatusChangedCompleted;
            listView.ItemContainerGenerator.StatusChanged();
        }
    private void StatusChangedCompleted(object source, SomeEventArgs e)
    {
        ListViewItem row = listView.ItemContainerGenerator.ContainerFromIndex(i) as ListViewItem;  
        if (row != null && row.Background != brush)  
        {  
            row.Background = brush;  
        }  
    }
