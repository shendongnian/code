    if (!Page.IsPostBack)
    {
    // Populate DropDownList
    for (int i = 1; i < 1001; i++)
    {
    ListItem li = new ListItem(i.ToString(),i.ToString());
    test.Items.Add(li);
    }
