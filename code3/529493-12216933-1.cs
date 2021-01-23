    protected void GridViewRowEventHandler(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           Label flag = (Label)e.Row.FindControl("progress_Flags");
           DropDownList myDropDown = (DropDownList)e.Row.FindControl("DropDownList1");
            if (flag.Text == "1")
            {
                myDropDown.SelectedValue = "1";
            }
        //add more conditions here..
        }          
    }
