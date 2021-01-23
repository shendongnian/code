    protected void btnEdit_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        LinkButton btnEdit = (LinkButton)clickedRow.FindControl("btnEdit");
        string any_data_for_gridview = clickedRow.Cells[1].Text; //change number 1
        string any_data_for_ddl = ddl.SelectedValue.ToString();
    }
