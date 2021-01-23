    Dictionary<string, string> list = new Dictionary<string, string>();
    for each item in datasource
    {
    list.Add(item.key, item.value);
    }
    if (ddl1.SelectedValue != defaultValue){
       var itemToRemove = list.First(kvp => kvp.Value == ddl1.SelectedValue);
       dic.Remove(itemToRemove .Key);
    }
    ddl2.DataSource = list;
    ddl2.DataTextField = "Value";
    ddl2.DataValueField = "Key";
    ddl2.DataBind();
