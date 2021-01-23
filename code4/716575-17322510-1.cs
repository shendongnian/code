    protected void LinkButton1_Click(object sender, EventArgs e)
      {
    GridViewRow clickedRow = ((LinkButton) sender).NamingContainer as GridViewRow;
    clickedRow.Visible = false;
      }
