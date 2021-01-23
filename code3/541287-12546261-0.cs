    var checkedItems = checkedListBox1.SelectedItems;
    
                foreach (var item in checkedItems)
                {
                    if (!checkedListBox2.Items.Contains(item))
                    {
                        checkedListBox2.Items.Add(item);
                    }
                }
