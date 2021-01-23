    protected void CheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxList cbx = (CheckBoxList)sender;
        _ListBox.Items.Clear();
        foreach (ListItem item in cbx.Items)
        {
            if(item.Selected)
                _ListBox.Items.Add(new ListItem(item.Text, item.Value));
        }
    }
