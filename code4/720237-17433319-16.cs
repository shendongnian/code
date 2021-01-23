     private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get all the virtually selected items
            List<CustomListBoxItem> selectedItems =
                listBox.Items.Cast<CustomListBoxItem>().Where(x => x.IsVirtuallySelected).ToList();
            if (selectedItems == null || !selectedItems.Any())
                return;
            // Do something with the selected items
            DoCoolStuffWithSelectedItems();
            // Unselsect all.
            listBox.Items.Cast<CustomListBoxItem>().ToList().ForEach(x => x.IsVirtuallySelected = false);
            listBox.UnselectAll();
        }
