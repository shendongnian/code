    protected void btn_GrdClick(object sender, EventArgs e)
    {
        if(Session["PreviousRowIndex"] != null)
        {
          var previousRowIndex = (int)Session["PreviousRowIndex"];
          GridViewRow PreviousRow = MyGridView.Rows[previousRowIndex];
          PreviousRow.ForeColor = Color.White;
        }
            
        GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
        row.ForeColor = Color.Yellow;
        Session["PreviousRowIndex"] = row.RowIndex;
    }
