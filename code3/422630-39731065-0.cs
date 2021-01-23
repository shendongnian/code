     protected void Remove_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < ListBox.Items.Count; i++)
        {
            ListBox.Items.Remove(ListBox.SelectedItem); 
        }
    }
