            List<ListItem> itemsToRemove = new List<ListItem>();
            foreach (ListItem listItem in ListBox1.Items)
            {
                if (listItem.Selected)
                    itemsToRemove.Add(listItem);
            }
            foreach (ListItem listItem in itemsToRemove)
            {
                ListBox1.Items.Remove(listItem);
            }
