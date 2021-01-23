    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {                
        if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 1)
        {
            e.Control.KeyPress += TextboxNumeric_KeyPress;
        }
    }
