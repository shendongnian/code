    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       ddl1Changed(DropDownList1.SelectedValue);
    }
    
    public void ddl1Changed(string selectedValue)
    {
        DataSet ds = softwareType(Convert.ToInt32(selectedValue));
        if (ds.Tables.Count > 0)
        {
            DropDownList2.DataTextField = "identifier";
            DropDownList2.DataValueField = "ST_ID"; //Change field to one you want.
            DropDownList2.DataSource = ds.Tables[0];
            DropDownList2.DataBind();
        }
    }
