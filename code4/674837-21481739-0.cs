    private void _addSelectItem(DropDownList list, string title, string value, string group = null) {
       ListItem item = new ListItem(title, value);
       if (!String.IsNullOrEmpty(group))
       {
           item.Attributes["data-category"] = group;
       }
       list.Items.Add(item);
    }
    ...
    _addSelectItem(dropDown, "Option 1", "1");
    _addSelectItem(dropDown, "Option 2", "2", "Category");
    _addSelectItem(dropDown, "Option 3", "3", "Category");
    ...
