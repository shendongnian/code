    protected void btnEdit_Click(object sender, EventArgs e)
    {
          ImageButton ib = sender as ImageButton;
            GridViewRow row = ib.NamingContainer as GridViewRow;
      Response.Redirect("/Secured/EditApplication.aspx?AppID="+YourGridViewId.Rows[row.RowIndex].Cells[1].Text);
    }
