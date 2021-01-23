    protected void DropDownList1_SelectedIndexChanged(Object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList) sender;
        IEnumerable<ListItem> selectedTasks = ddl.Items
            .Cast<ListItem>().Where(li => li.Selected);
     
        foreach(ListItem item in selectedTasks)
        {
            DropDownList2.Items.Remove(item);
            DropDownList3.Items.Remove(item);
            DropDownList4.Items.Remove(item);
            DropDownList5.Items.Remove(item);
            // ...
        }
    }
