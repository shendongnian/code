    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        // For shading rows
        if (dataGridView1.Rows.Count > 0)
        {
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;
        }
        // For shading columns
        int colNum = 2; // Add your own code to get the column number you want
        dataGridView1.Columns[colNum].DefaultCellStyle.BackColor = Color.LightGray;
    }
