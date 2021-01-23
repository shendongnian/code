    for (var i = 0; i <= 10; i++)
            {
                if (mylistview.Items != null) mylistview.Items.Add("Item at index "+i);
            }
            if (mylistview.Items != null)
            {
                for (var i = 0; i <= mylistview.Items.Count - 1; i++)
                {
                    if (i > 4)
                    {
                        mylistview.SelectedItems.Add(mylistview.Items[i]);
                    }
                }
            }
