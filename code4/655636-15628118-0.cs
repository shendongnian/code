    protected void MoveRight(object sender, EventArgs e)
    {
        int max = Convert.ToInt32(DropDownList1.SelectedValue);
        for(int i=0;i<max && ListBox1.Items.Count > 0 && ListBox1.SelectedItem != null; i++)
        {
            ListItem selectedItem = ListBox1.SelectedItem;
            selectedItem.Selected = false;
            ListBox2.Items.Add(selectedItem);
            ListBox1.Items.Remove(selectedItem);
       }
