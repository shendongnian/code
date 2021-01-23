        // Set the selection background color for all the cells.
    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
    // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
    // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
    dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty;
    // Set the background color for all rows and for alternating rows.  
    // The value for alternating rows overrides the value for all rows. 
    dataGridView1.RowsDefaultCellStyle.BackColor = Color.LightGray;
    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
