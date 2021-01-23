    protected void GridViewType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      GridViewRow row = (GridViewRow)(e.CommandSource);
      Button btnVote = row.FindControl("btnVote");
      btnVote.Enabled = false;
    }
