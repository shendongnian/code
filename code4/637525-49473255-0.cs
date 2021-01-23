        foreach (ListItem item in yourListITem.Items)
    {
        if (item.Text == yourNewListITemText.SelectedItem.Text)
        {
            empAdd = 0;
        }
    }
    if(empAdd==0)
    {
    //Item Exist....
    }
    else
    {
    //New Add
     yourListBox.Items.Add(new ListItem(yourlistbox.SelectedItem.ToString(), yourlistbox.SelectedValue.ToString()));
    }
