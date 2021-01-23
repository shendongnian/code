    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if(e.RowIndex >= 0 && e.ColumnIndex >= 0)  //to disable the row and column headers
        {
           Txt_GangApproved.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
    }
