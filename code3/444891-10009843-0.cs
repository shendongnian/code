    DataGridViewRowCollection coll = dataGridView1.Rows; 
    
    DataTable t = new DataTable(); 
    
    t.Columns.Add(); 
    
    foreach (DataGridViewRow item in coll) 
    
    {
         t.Rows.Add(item.Cells[0].Value);
    }
