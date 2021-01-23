    protected void DetailsView1_ItemCommand(Object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName == "btnSelectAll")
        {
            foreach (var row in DetailsView1.Rows)
            {
                (row.Cells[1].Controls[0] as CheckBox).Checked = true;
            }
        }
    }
