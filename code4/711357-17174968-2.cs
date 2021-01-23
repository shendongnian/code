    protected void GridViewType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      GridViewRow row = (GridViewRow)(e.CommandSource);
      Button btnVote = (Button)row.FindControl("btnVote");
      btnVote.Enabled = false;
    }
