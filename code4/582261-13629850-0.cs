    dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value == null || String.IsNullOrWhiteSpace(e.Value.ToString()))
        {
            e.CellStyle.BackColor = Color.Green;
        }
        else
        {
            e.CellStyle.BackColor = Color.White;
        }            
    }
