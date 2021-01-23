    private void dgv_buttonCol(object sender, DataGridViewCellEventArgs e)
    {
            if (e.ColumnIndex != 4) // Change to the index of your button column
            {
                 return;
            }
 
            if (e.RowIndex > -1)
            {
                string name = Convert.ToString(dgv.Rows[e.RowIndex].Cells[2].Value);
                ShowRichMessageBox("Code", name);
            }
    }
