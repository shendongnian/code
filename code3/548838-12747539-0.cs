    dataGridView1.AutoGenerateColumns = false;
        
    DataTable dt = new DataTable();
    dt.Columns.Add("Name", typeof(String));
    dt.Columns.Add("Money", typeof(String));
    dt.Rows.Add(new object[] { "Hi", 100 });
    dt.Rows.Add(new object[] { "Ki", 30 });
        
    DataGridViewComboBoxColumn money = new DataGridViewComboBoxColumn();
    var list11 = new List<string>() { "10", "30", "80", "100" };
    money.DataSource = list11;
    money.HeaderText = "Money";
    money.DataPropertyName = "Money";
        
    DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
    name.HeaderText = "Name";
    name.DataPropertyName = "Name";
        
    dataGridView1.DataSource = dt;
    dataGridView1.Columns.AddRange(name, money);
