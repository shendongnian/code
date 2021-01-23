    public void PopulateDropdownList2(int selectedValue)
    {
        DropDownList2.Items.Clear();
        DataSet ds = softwareType(selectedValue);
        if (ds.Tables.Count > 0)
        {
               DropDownList2.DataTextField = "identifier";
               DropDownList2.DataValueField = "ST_ID"; //Change field to one you want.
               DropDownList2.DataSource = ds.Tables[0];
               DropDownList2.DataBind();
        }
    }
