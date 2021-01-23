    private void btnGetSelected_Click(object sender, RoutedEventArgs e)
    {
        ListBoxItem selectedItem =this.listBox.ItemContainerGenerator.ContainerFromItem(this.listBox.SelectedItem) as ListBoxItem;
        var textblock = selectedItem.Content
    }
