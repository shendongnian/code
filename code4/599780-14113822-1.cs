    // Data source
    table = new DataTable("SomeTable");
    table.Columns.Add(NameColumn, typeof(string));
    table.Columns.Add(IdColumn, typeof(int));
    
    table.Rows.Add("First", 1);
    table.Rows.Add("Second", 2);
    table.Rows.Add("Third", 3);
    table.Rows.Add("Last", 4);
    
    // Combo box:
    this.comboBox1.DisplayMember = NameColumn;
    this.comboBox1.ValueMember = IdColumn;
    this.comboBox1.DataSource = table;
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
    this.comboBox1.TextChanged += comboBox1_TextChanged;
    this.comboBox1.SelectedIndexChanged += this.comboBox1_SelectedIndexChanged;
