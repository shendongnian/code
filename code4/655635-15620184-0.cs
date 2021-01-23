    protected void MoveRight(object sender, EventArgs e)
    {
        int max = 1;
        int iterations = ListBox1.Items.Count < max ? ListBox1.Items.Count : max
        for(int i = 0; i < iterations; i++)
        {
            ListItem selectedItem = ListBox1.SelectedItem;
            if(selectedItem == null)
                break;
           
            selectedItem.Selected = false;
            ListBox2.Items.Add(selectedItem);
            ListBox1.Items.Remove(selectedItem);
        }
    }
