    private void fillSecondDdl()
    {
    DataSet ds = softwareType(Convert.ToInt32(DropDownList1.SelectedValue));
        if (ds.Tables.Count > 0)
        {
            DropDownList2.DataTextField = "identifier";
            DropDownList2.DataValueField = "ST_ID"; //Change field to one you want.
            DropDownList2.DataSource = ds.Tables[0];
            DropDownList2.DataBind();
        }
    }
