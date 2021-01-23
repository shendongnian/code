    List<MyClass> values = //...
    cblMyList.DataSource = values;
    cblMyList.DataBind();
    foreach (ListItem item in this.cblMyList.Items)
    {
       if(interests.Contains(item.Value))
       {
        item.Selected = true;
       }
    }
