    // make sure to do it before binding DataGridView control
    datagridview.AutoGenerateColumns = false;
    
    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
    col1.DataPropertyName = "Name";
    col1.HeaderText = "Customer name";
    col1.Name = "column_Address";
    datagridview.Columns.Add(col1);
    
    DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
    col2.DataPropertyName = "Address";
    col2.HeaderText = "Address";
    col2.Name = "column_Name";
    datagridview.Columns.Add(col2);
