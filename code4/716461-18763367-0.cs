     protected void GrdViewMyTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink ViewDetails = e.Row.FindControl("ViewDetails") as HyperLink;
                ViewDetails.NavigateUrl = "Reports.aspx?TaskID=" + e.Row.Cells[0].Text;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Label)e.Row.Cells[0].FindControl("Description")).Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
            }
        }
    protected void GrdViewMyTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmdLink")
            {
                string TaskID = Convert.ToString(e.CommandArgument.ToString());
                Response.Redirect("Reports.aspx?TaskID=" + TaskID);
            }
        }
