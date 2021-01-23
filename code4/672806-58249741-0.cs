    private void DataGridView1_VisibleChanged(object sender, System.EventArgs e)
    {
        var grid = sender as DataGridView;
        grid.Rows[0].Cells[0].Style.BackColor = Color.Yellow;
    }
