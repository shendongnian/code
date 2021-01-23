    bool IsExist = dataGridView1.Rows.Cast<DataGridViewRow>()
                                       .Count(c => !string.IsNullOrWhiteSpace(c.Cells[colIndex].EditedFormattedValue.ToString()) &&
                                       c.Cells[colIndex].EditedFormattedValue.ToString().Trim() == dgv[colIndex, rowIndex].EditedFormattedValue.ToString()) > 1;
            
    if (IsExist)
    {
       //do stuff
    }
