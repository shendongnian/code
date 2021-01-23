    for(i=0;......;i++)
    {
        DataGridViewComboBoxCell ComboColumn = (DataGridViewComboBoxCell)
                                           (dataGridView1.Rows[i].Cells[0]);
        
        ComboColumn.DataSource = null;
        ComboColumn.items.clear();
        ComboColumn.HeaderText = "RoleP";      
        ComboColumn.DataSource = bindingSource;         
        // The display member is the name column in the column datasource  
        ComboColumn.DisplayMember = "Name";
        // The value member is the primary key of the protols table  
        ComboColumn.ValueMember = "Id";    
    }
