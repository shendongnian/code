    protected void yourGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
             //Get TextBoxes
             TextBox txtStartDate = yourGridViewName.SelectedRow.FindControl("txtStartDate") as TextBox;
             TextBox txtEndDate = yourGridViewName.SelectedRow.FindControl("txtEndDate") as TextBox;
             //Get text
             string startDate = txtStartDate.Text;
             string endDate = txtEndDate .Text;
             
             //Assign the function
             e.Row.Attributes.Add("Onchange", "CompareDates('" + startDate + "', '" + endDate + "'");
        }
    }
