    private void bindDropDownList()
    {
       DropDownList1.DataTextField = "price";
       DropDownList1.DataSource = getReader();
       DropDownList1.DataBind();
       DropDownList1.Items.Insert(0, new ListItem("-Select-"));
       DropDownList1.Items.Insert(1, new ListItem("Price - Highest to Lowest"));
       DropDownList1.Items.Insert(2, new ListItem("Price - Lowest to Highest"));
    }
