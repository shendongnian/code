     protected void Button1_Click(object sender, EventArgs e)
        {
            if (ListBox2.SelectedIndex != -1)
            {
    
                ListItem item = ListBox2.SelectedItem;
                item.Selected = false;
                ListBox1.Items.Add(item);
                
            }
        }
