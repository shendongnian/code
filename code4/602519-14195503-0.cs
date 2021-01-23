    //You can assign the Column types while initializing
    DataGridViewColumn d1 = new DataGridViewTextBoxColumn();
    DataGridViewColumn d2 = new DataGridViewCheckBoxColumn();
    DataGridViewColumn d3 = new DataGridViewImageColumn();
    
    //Add Header Texts to be displayed on the Columns
    d1.HeaderText = "Column 1"; 
    d2.HeaderText = "Column 2";
    d3.HeaderText = "Column 3";
    
    //Add the Columns to the DataGridView
    DataGridView1.Columns.AddRange(d1, d2, d3);
    
    //Finally add the Rows
    DataGridView1.Rows.Add(5);
