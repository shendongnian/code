     protected void Remove_Click(object sender, EventArgs e)
    {
        while (ListBox.GetSelectedIndices().Length > 0)
        {
            ListBox.Items.Remove(ListBox.SelectedItem); 
        }
    }
