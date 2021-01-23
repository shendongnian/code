    if (myListView.SelectedItems.Count > 0)
    {
        foreach ([Class] cl in [List])
        {
            if (myListView.SelectedItems[0].SubItems[0].Text == cl.[Field].ToString())
            {
                RichTextBox.Text = cl.[Field];
            }
        }
    }
