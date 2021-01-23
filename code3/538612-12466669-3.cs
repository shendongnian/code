    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       DataGridViewRow row = GridView1.SelectedRow;
        if (this.row.SelectedRows.Count == 1)
        {
            Response.Redirect("UsageHistoryPage.aspx?EntityID=" + row.SelectedRows[0].Cells[0].ToString());
        }
    }
