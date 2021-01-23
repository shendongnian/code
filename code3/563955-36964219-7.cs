     private void ClearDataGridViewLoopWhile()
    {           
        while (dataGridView1.Rows.Count > 1)
        {
            dataGridView1.Rows.RemoveAt(0);
        }
        while (dataGridView1.Columns.Count > 0)
        {
            dataGridView1.Columns.RemoveAt(0);
        }
    }
    private void ClearDataGridViewForEach()
    {
        foreach (object _Cols in dataGridView1.Columns)
        {
            dataGridView1.Columns.RemoveAt(0);
        }
        foreach (object _row in dataGridView1.Rows)
        {
            dataGridView1.Rows.RemoveAt(0);
        }
    }
