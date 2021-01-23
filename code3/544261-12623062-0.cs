    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row1 in dataGridView1.Rows)
        {
            if (row1.Cells.Cast<DataGridViewCell>().Any(c => c.Value == null || string.IsNullOrWhiteSpace(c.Value.ToString())))
            {
                row1.DefaultCellStyle.BackColor = Color.Violet;
            }
            else
            {
                row1.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
