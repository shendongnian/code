    CheckBoxList chkl = new CheckBoxList();
        string[] items = { "item1", "item2", "item3", "item4", "item5" };
        foreach (string item in items)
        {
            chkl.Items.Add(new ListItem(item));
        }
        chkl.AutoPostBack = true;
        chkl.CssClass = "3";
        chkl.SelectedIndexChanged += new EventHandler(BoxChecked);
