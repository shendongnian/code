    if (listView1.SelectedItems.Count > 0)
    {
        MessageBox.Show("You clicked " + listView1.SelectedItems[0].Text);
    }
    else
    {
         MessageBox.Show("Please select an item");
    }
