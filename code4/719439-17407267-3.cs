    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ID"));
            //identifying the control in gridview
            ImageButton lnkbtnresult = (ImageButton)e.Row.FindControl("imgbtnDelete");
            //raising javascript confirmationbox whenver user clicks on link button
            if (lnkbtnresult != null)
            {
                lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + id + "');");
            }
    
        }
