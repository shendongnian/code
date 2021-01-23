    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
           //check condition and assign color
           e.CellStyle.BackColor = Color.Red;                    
        }
     }
