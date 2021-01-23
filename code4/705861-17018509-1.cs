    private void dataGridView1_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)    
    {
    String sCellName =  dataGridView1.Columns(e.ColumnIndex).Name; 
        If (UCase(sCellName) == "QUANTITY") //----change with yours
        {
            
            e.Control.KeyPress  += new EventHandler(CheckKey);
            
         }
    }
    
    private void CheckKey(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) 
            && !char.IsDigit(e.KeyChar) 
            && e.KeyChar != '.')
        {
            e.Handled = true;
        }   
    }
