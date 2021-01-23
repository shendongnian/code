    // Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns();
    // Configure the details DataGridView so that its columns automatically 
    // adjust their widths when the data changes.
  
     private void SizeAllColumns(Object sender, EventArgs e)
    {
        dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells); 
       dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
    }
