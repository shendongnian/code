    GridViewComboBoxColumn CustomColumn= new GridViewComboBoxColumn();
    CustomColumn.Name = "CustomColumn";
    CustomColumn.HeaderText = "MyHeader";
    CustomColumn.DataSource = this.MyBindingSource;
    CustomColumn.ValueMember = "CustomID";
    CustomColumn.DisplayMember = "CustomName";
    CustomColumn.FieldName = "CustomID";
    CustomColumn.Width = 200;
    this.radGridView1.Columns.Add(CustomColumn);
