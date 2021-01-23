    private void listBox_MouseMove(object sender, MouseEventArgs e)
        {
            bool itemFound = false;
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var currentItem = listBox.ItemContainerGenerator.ContainerFromIndex(i) as CustomListBoxItem;
                if (currentItem == null) 
                    continue;
                // Check whether the cursor is on an item or not.
                if (IsMouseOverItem(currentItem, e.GetPosition((IInputElement)currentItem)))
                {
                    // Unselect all items before selecting the new group
                    listBox.Items.Cast<CustomListBoxItem>().ToList().ForEach(x => x.IsVirtuallySelected = false);
                    // Select the current item and the ones above it
                    for (int j = 0; j <= listBox.Items.IndexOf(currentItem); j++)
                    {
                        ((CustomListBoxItem)listBox.Items[j]).IsVirtuallySelected = true; 
                    }
                    itemFound = true;
                    break;
                }
            }
            // If the item wasn't found for the mouse point, it means the pointer is not over any item, so unselect all.
            if (!itemFound)
            {
                listBox.Items.Cast<CustomListBoxItem>().ToList().ForEach(x => x.IsVirtuallySelected = false);
            }
        }
