    //Set columns to Datagridview  
    DataGridViewImageColumn btnEdit = new DataGridViewImageColumn();  
    Image gear = (System.Drawing.Image)Properties.Resources.gear;  
    btnEdit.Image = gear;  
    datagridview.Columns.Add(btnEdit);  
    
    //Table  
    DataGridViewComboBoxColumn cbTable = new DataGridViewComboBoxColumn();  
    cbTable.HeaderText = "Table";  
    cbTable.Name = "Table";  
    cbTable.DisplayMember = "NameToShow";  
    datagridview.Columns.Add(cbTable);  
    
    //...  
    //...  
    //...  
    
    //Load data  
    ((DataGridViewComboBoxColumn)datagridview.Columns[1]).Itens = (List<Table>)moduleClone.SqlQuery.Tables;  
    //Work just fine  
    
    //...  
    //...  
    //...  
    
    //Now I reload de data  
    datagridview.Rows.Clear();
    ((DataGridViewComboBoxColumn)datagridview.Columns[1]).DataSource = null; 
    ((DataGridViewComboBoxColumn)datagridview.Columns[1]).Items.clear();
    ((DataGridViewComboBoxColumn)datagridview.Columns[1]).Items= (List<Table>)moduleClone.SqlQuery.Tables;
