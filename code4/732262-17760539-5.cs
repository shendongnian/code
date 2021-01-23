    private void calculateSumColumn(int curColumn)
    {
        double valueCurColumn = 0;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
             valueCurColumn = valueCurColumn + (double)row.Cells[curColumn].Value;
        }
    
        textBox1.Text = valueCurColumn.ToString();
    }
