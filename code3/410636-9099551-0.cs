    /// <summary>
    /// Shows example usage of Add method on Rows.
    /// </summary>
    void M()
    {
        //
        // n is the new index. The cells must also be accessed by an index.
        // In this example, there are four cells in each row.
        //
        int n = dataGridView1.Rows.Add();
        dataGridView1.Rows[n].Cells[0].Value = title;
        dataGridView1.Rows[n].Cells[1].Value = dateTimeNow;
    
        //
        // The second cell is a date cell, use typeof(DateTime).
        //
        dataGridView1.Rows[n].Cells[1].ValueType = typeof(DateTime);
        dataGridView1.Rows[n].Cells[2].Value = wordCount;
    }
