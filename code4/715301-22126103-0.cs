    int ab;
                   
     int PIrowss = dataGridView2.Rows.Count;
                   
     for (ab = 0; ab < PIrowss; ab++)
                   
     {
                       
     PiCGetAutID();
                       
     purchaeOrder.pcautoid = Catget;
                       
     purchaeOrder.ponum = label119.Text;
                       
     purchaeOrder.col1 = dataGridView2.Rows[ab].Cells[0].Value.ToString();
                       
     purchaeOrder.col2 = dataGridView2.Rows[ab].Cells[1].Value.ToString();
                       
     purchaeOrder.col3 = dataGridView2.Rows[ab].Cells[2].Value.ToString();
                       
     purchaeOrder.col4 = dataGridView2.Rows[ab].Cells[3].Value.ToString();
                      
      purchaeOrder.col5 = dataGridView2.Rows[ab].Cells[4].Value.ToString();
                      
     
     purchaeOrder.POcSave();
    
    }
