    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList dd = (DropDownList)sender;
        // you can get dropdown from table row over here.
        // process with it as per your requirement.
        string strdropdownID = ((System.Web.UI.Control)(dd)).ID;
    }
