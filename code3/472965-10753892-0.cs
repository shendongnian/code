    private void dgv_buttonCol(object sender, DataGridViewCellEventArgs e)
    {
            if (e.ColumnIndex != 4) // Change to the index of your button column
            {
                 return;
            }
 
            // Make sure there is a selected row first:
            if (dgv.SelectedRows.Count > 0)
            {
                string name = Convert.ToString(dgv.SelectedRows[0].Cells[2].Value);
                ShowRichMessageBox("Code", name);
            }
    }
