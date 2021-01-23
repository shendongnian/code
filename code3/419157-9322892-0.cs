    //Create 2 datasource for combobox in grid
                    DataTable genderTable= new DataTable();
                    genderTable.Columns.Add(new DataColumn("Value", typeof(int)));
                    genderTable.Columns.Add(new DataColumn("Name", typeof(String)));
                    genderTable.Rows.Add(new object[] { 0, 'male'});
                    genderTable.Rows.Add(new object[] { 1, 'female'});
        
                    DataTable countryTable= new DataTable();
                    countryTable.Columns.Add(new DataColumn("Value", typeof(int)));
                    countryTable.Columns.Add(new DataColumn("Name", typeof(String)));
                    countryTable.Rows.Add(new object[] { 0, 'USA'});
                    countryTable.Rows.Add(new object[] { 1, 'Germany'});
        
    //Create 2 combobox column
                     DataGridViewColumn gender= new DataGridViewColumn(new DataGridViewComboBoxCell());
                     DataGridViewColumn country= new DataGridViewColumn(new DataGridViewComboBoxCell());
                  
    //Add column into grid
                    dataGridView1.Columns.Add(gender);
                    dataGridView1.Columns.Add(country);
    // Add rows into grid, number of rows is 10 
                    dataGridView1.Rows.Add(10);
        
                    for (int i = 0; i < 10; i++) {
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[0]).DataSource = genderTable;
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[0]).DisplayMember = "Name";
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[0]).ValueMember = "Value";
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[0]).Value = 0;
        
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).DataSource = countryTable;
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).DisplayMember = "Name";
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).ValueMember = "Value";
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1]).Value = 0;
             }
