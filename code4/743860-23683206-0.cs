      foreach (ListViewItem item in listView1.Items)
        {
            if (item.Text == "searchTerm")
            {
                // do something
            }
            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                if (subItem.Text == "searchTerm")
                {
                    // do something
                }
            }
        }
