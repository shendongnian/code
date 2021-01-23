    foreach (ListItem item in DropDownList1.Items)
    {
        //if you want to apply for some selected items check the condition on item.Text or item.Value based on your requirement.
        if (item.Text == "Some Value")
        {
            //Change font weight 
            item.Attributes.CssStyle.Add("font-weight", "bold");
            //Change font color
            item.Attributes.CssStyle.Add("color", "red");
        }
    }
