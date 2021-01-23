    void dataGridView1_CellFormatting(object sender, 
                                      DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.Value = e.RowIndex;
            return;
        }
    
        e.Value = dataGridView1.Rows[e.RowIndex].DataBoundItem;
    }
