    dataGridView.ColumnAdded += DataGridViewColumnAdded;
    dataGridView.DataSource = dataTable;
    private void DataGridViewColumnAdded(Object sender, DataGridViewColumnEventArgs e) 
    {
       if(e.Column.ValueType == typeof(MyEnumType)) 
       {
          DataGridViewComboBoxColumn cb = new DataGridViewComboBoxColumn();
          cb.HeaderText       = "My header text";
          cb.ValueType        = typeof(MyEnumType);
          cb.DataSource       = Enum.GetValues(typeof(MyEnumType));
          cb.FlatStyle        = FlatStyle.System;
          cb.Name             = "Name";
          cb.DataPropertyName = "Name"; 
          cb.DisplayStyle     = DataGridViewComboBoxDisplayStyle.Nothing;
          e.Column.CellTemplate = cb;
       } 
    }
