    protected void Button1_Click(object sender, EventArgs e)
    {
        List<ListItem> selectedItems = new List<ListItem>();
        if (leftbox.SelectedIndex >= 0)
        {
            for (int i = 0; i < leftbox.Items.Count; i++)
            {
                if (leftbox.Items[i].Selected)
                {
                        selectedItems.Add(leftbox.Items[i]);
                }
            }
    
        }
    
        for (int i = 0; i < selectedItems.Count; i++)
        {
            if (!rightbox.Items.Contains(selectedItems[i]))
                rightbox.Items.Add(selectedItems[i]);
            leftbox.Items.Remove(selectedItems[i]);
        }
       
    }
