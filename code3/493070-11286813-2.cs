    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("AddCustomEventNote"))
        {
            DropDownList eventnoteAddDrpDwnLst = (DropDownList)grid.FooterRow.FindControl("eventnoteAddDrpDwnLst");
            string value = eventnoteAddDrpDwnLst.SelectedValue;
        }
    }
