    protected void GrdV_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GrdV.Rows[e.RowIndex]; // this line is changed      
        TextBox t1 = row.FindControl("descTbx") as TextBox;
        DataTable dt = (DataTable)Session["tmdataTable"];
        dt.Rows[index]["Description"] = t1.Text; //Description is a column of my DataTable
        dt.AcceptChanges();
        GrdV.EditIndex = -1;
        GrdV.DataSource = dt;
        GrdV.DataBind();
    }
