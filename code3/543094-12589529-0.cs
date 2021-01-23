    private void dataGridView1_EditingControlShowing(object sender, 
        DataGridViewEditingControlShowingEventArgs e)
    {
        if(e.ColumnIndex == 3)//select target column
        {
        TextBox textBox = e.Control as TextBox;
        if (textBox != null)
        {
            textBox.UseSystemPasswordChar = true;
        }
        }
    }	
    
 
