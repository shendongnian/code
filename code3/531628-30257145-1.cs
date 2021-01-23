    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = e.RowIndex;
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        
        TextBox PrStyle = (TextBox)row.FindControl("PrStyle");
        TextBox PrID = (TextBox)row.FindControl("PrID");
        GridView1.EditIndex = -1;
        SqlCommand cmd = new SqlCommand("Update dt Set PrStyle='" + PrStyle + "',PrID='" + PrID + "'");
    }
