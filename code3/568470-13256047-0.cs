             private Object newCellValue;
             private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
             {
                 if (dataGridView1.CurrentCell.IsInEditMode)
                 {
                     if (dataGridView1.CurrentCell.GetType() ==
                     typeof(DataGridViewComboBoxCell))
                     {
                         DataGridViewComboBoxCell cell =
                         (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
                         if (!cell.Items.Contains(e.FormattedValue))
                         {
                             cell.Items.Add(e.FormattedValue);
    
                             cell.Value = e.FormattedValue;
    
                             //keep the new value in the member variable newCellValue
                             newCellValue = e.FormattedValue;
                         }
                     }
                 }
             }
    
             private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
             {
                 if (e.Control.GetType() ==
    typeof(DataGridViewComboBoxEditingControl))
                 {
                     ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                 }
             }
    
             private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
             {
                 if (dataGridView1.CurrentCell.GetType() ==
                     typeof(DataGridViewComboBoxCell))
                 {
                     DataGridViewCell cell =
                     dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                     cell.Value = newCellValue;
                 }
             }
