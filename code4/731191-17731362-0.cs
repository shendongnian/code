    void SetOptions()
    {
        DropDownList.Items.Clear();
        var options = Enum.GetValues(ListType); // need to cast this to type of ListType
        foreach (var o in options)
        {
            var item = new ListItem(o.Description(), o.ToString());
            item.Tag = o;
            DropDownList.Items.Add(item);
        }
    }
