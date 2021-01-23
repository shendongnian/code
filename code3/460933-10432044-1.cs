    dataGridView.ColumnAdded += DataGridViewColumnAdded;
    dataGridView.DataSource = dataTable;
    private void DataGridViewColumnAdded(Object sender, DataGridViewColumnEventArgs e) 
    {
       if(e.Column.ValueType == typeof(MyEnumType)) 
       {
          DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
          cb.ValueType        = typeof(MyEnumType);
          cb.DataSource       = Enum.GetValues(typeof(MyEnumType));
          cb.FlatStyle        = FlatStyle.System;
          cb.DisplayStyle     = DataGridViewComboBoxDisplayStyle.Nothing;
          e.Column.CellTemplate = cb;
       } 
    }
