    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var value= String.Format("You selected row {0} with {1} {2}",
                                                GridView1.SelectedIndex + 1,
                                                GridView1.SelectedRow.Cells[0].Text,
                                                GridView1.SelectedRow.Cells[1].Text);
    }
