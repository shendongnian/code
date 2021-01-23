    private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        int index = e.RowIndex;
        for (int i = 0; i < e.RowCount; i++)
        {
            DataGridViewImageCell tmp = (DataGridViewImageCell)DataGridView1.Rows[index].Cells[0];
            DataGridView1ValidateFields.AddRow(tmp);
            index++;
        }
    }
