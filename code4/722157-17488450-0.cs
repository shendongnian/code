        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        //check if currently selected cell is cell you want
        if (dataGridView1.CurrentCell == null || dataGridView1.CurrentCell.ColumnIndex != 2)
        {
            return;
        }
        if (e.Control is TextBox && !(Convert.ToBoolean(this.dataGridView1.CurrentRow.Cells[8].Value.ToString())))
        {
             if(isFirstTime)
             { 
            ((TextBox)e.Control).MaxLength = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value.ToString());
              isFirstTime=false;
        }
        }
    }
