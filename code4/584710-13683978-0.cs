    if (!IsPostBack)
    {
        foreach (ListItem item in chkList.Items)
        {
            //adding a dummy class to use at client side.
            item.Attributes.Add("class", "chkItem");
        }
    }
