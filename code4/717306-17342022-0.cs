    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
       //check if currently selected cell is cell you want
       if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.ColumnIndex != 2)
       {
           return;
       }
    
       if (e.Control is TextBox)
       {
           ((TextBox)e.Control).MaxLength = 130;
       }
    }
