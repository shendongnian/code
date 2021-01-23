    			DataTable dt = new DataTable();
    			dt.Columns.Add("Name", typeof(String));
    			dt.Columns.Add("Money", typeof(String));
    			dt.Rows.Add(new object[] { "Hi", 100 });
    			dt.Rows.Add(new object[] { "Ki", 30 });
    
    			DataTable dt2 = new DataTable();
    			dt2.Columns.Add("Money", typeof(String));
    			dt2.Columns.Add("Meaning", typeof(String));
    			dt2.Rows.Add(new object[] { "30" ,"Name 1" });
    			dt2.Rows.Add(new object[] { "100", "Name 2" });
    			dt2.Rows.Add(new object[] { "80", "Name 3" });
    			dt2.Rows.Add(new object[] { "90", "Name4" });
    
    			DataGridViewComboBoxColumn money = new DataGridViewComboBoxColumn();
    			
    			money.DataSource = dt2;
    			money.HeaderText = "Money";
    			money.DataPropertyName = "Money";
    			money.DisplayMember = "Meaning";
    			money.ValueMember = "Money";
    
    			DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
    			name.HeaderText = "Name";
    			name.DataPropertyName = "Name";
    
    			DGV.Columns.Add(money);
    			DGV.Columns.Add(name);
    			DGV.DataSource = dt;
