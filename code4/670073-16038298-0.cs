    DataGridViewCheckBoxColumn CBColumn = new DataGridViewCheckBoxColumn();
    CBColumn.HeaderText = "ColumnHeader";
    CBColumn.FalseValue = "0";
    CBColumn.TrueValue = "1";
    dataGridView1.Columns.Insert(0, CBColumn);
