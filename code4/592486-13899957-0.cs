    private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            if (dgv[e.ColumnIndex, e.RowIndex].Value.ToString() !="S" )
            {
                MessageBox.Show("You have to enter S");
            }
        }
    }
