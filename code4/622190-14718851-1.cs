    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
     if (dataGridView1.SelectedRows.Count > 0)
        {
        
        foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
            //Send the first cell value into textbox'
            Txt_FirstName.Text = row.Cells(0).Value.ToString; // or row.Cells["ColumnName"].Value;
              }
        }
    }
