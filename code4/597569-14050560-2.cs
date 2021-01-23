    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
    cmb.HeaderText = "RoleP";      
    cmb.DataSource = bindingSource;         
       // The display member is the name column in the column datasource  
    cmb.DisplayMember = "Name";
       // The value member is the primary key of the protols table  
    cmb.ValueMember = "Id";    
    dataGridView1.Columns.Add(cmb);
