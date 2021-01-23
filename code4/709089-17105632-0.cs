    if (ListBox.SelectedIndex == -1)
            {
                if (ListBox.NumberOfItems == 0) // if no index, need to select a row!
                {
                    MessageBox.Show("No items to remove!");
                }
                else
                {
                    MessageBox.Show("Please select an item first!");
                }
            }
            else
            {
                 lstStorage.Items.RemoveAt(lstStorage.SelectedIndex);
            }
