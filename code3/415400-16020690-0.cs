    private void AccountItemsT33_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        // If have selected an item via left click, then do a right click, need to disable that initial selection
        AccountItemsT33.SelectedIndex = -1;
        VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(null), (sender as ListBox)).OfType<ListBoxItem>().First().IsSelected = true;
    }
