    int RowIndex;
    protected void gvName_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvName.SelectedRow;
        string name = gvName.Rows[RowIndex].Cells[1].Text; //Gets column
        //With DataKey
        string name = gvName.DataKeys[RowIndex]["TicketId"].ToString();
        Response.Redirect("~/secondpage.aspx?ServiceCenter=" + name);
    }
    protected void gvName_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Gets Gridview row number when clicked
        RowIndex = Convert.ToInt32(e.CommandArgument);
    }
