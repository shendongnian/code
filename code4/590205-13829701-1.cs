    //Adding  Month Combo
    DataGridViewComboBoxColumn ColumnMonth = new DataGridViewComboBoxColumn();
    ColumnMonth.DataPropertyName = "MonthID";
    ColumnMonth.HeaderText = "Month";
    ColumnMonth.Width = 120;
    ColumnMonth.DataSource = bindingSourceMonth;
    ColumnMonth.ValueMember = "MonthID";
    ColumnMonth.DisplayMember = "MonthText";
    dataGridViewComboTrial.Columns.Add(ColumnMonth);
