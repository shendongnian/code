    void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewColumn c = dataGridView1.Columns[e.ColumnIndex];
        if (c.AutoSizeMode == DataGridViewAutoSizeColumnMode.None)
        {
            Size s = TextRenderer.MeasureText(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString(), dataGridView1.Font);
            if (s.Width > c.Width)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            }
        }
    }
