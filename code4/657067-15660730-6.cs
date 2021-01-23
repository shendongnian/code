    protected void Colour_Columns(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label StatusLabel = e.Row.FindControl("StatusLabel") as Label;
            if (StatusLabel.Text == "Match")
               e.Row.BackColor = Color.Lime;
            if (StatusLabel.Text == "Mismatch")
               e.Row.BackColor = Color.Gold;
            if (StatusLabel.Text == "New File")
               e.Row.BackColor = Color.PeachPuff;
        }
    }
