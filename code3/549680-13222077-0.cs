    //Primary Continuation
    for (int i = 7; i < dataGridView2.Columns.Count + 1; i++)
    {
        worksheet.Cells[7, i] = dataGridView2.Columns[i - 1].HeaderText;
    }
