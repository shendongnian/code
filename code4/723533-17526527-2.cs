    // Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns();
    // Configure the details DataGridView so that its columns automatically 
    // adjust their widths when the data changes.
    DataGridView1.AutoSizeColumnsMode = 
        DataGridViewAutoSizeColumnsMode.AllCells; 
