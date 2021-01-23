    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
       txtname.Text = GridView2.SelectedRow.Cells[1].Text;
       cboCountry.SelectedItem.Text = GridView2.SelectedRow.Cells[2].Text;
    }
