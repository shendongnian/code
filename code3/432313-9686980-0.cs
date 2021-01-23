    private void allTaskListTasksListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {   
        if(e.AddedItems.Count > 0) // the items that were added to the "selected" collection
        {
            var mySelectedItem = e.AddedItems[0] as myItemType;
            if(null != mySelectedItem) // prevents errors if casting fails
            {
                NavigationService.Navigate(
                   new Uri("/View/Details.xaml?msg=" + mySelectedItem.Crm_object_id, 
                           UriKind.RelativeOrAbsolute)
                );
            }
        }
    }
