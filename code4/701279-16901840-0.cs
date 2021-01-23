    //This is to copy the SelectedRows every time user releases the Control key
    DataGridViewRow[] selectedRows;
    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e){
         if(selectedRows == null) return;
         if(!selectedRows.Contains(dataGridView.Rows[e.RowIndex])){
           //Restore the BackColor and ForeColor of the selected rows
           foreach(DataGridViewRow row in selectedRows){
               row.DefaultCellStyle.BackColor = dataGridView.DefaultCellStyle.BackColor;
               row.DefaultCellStyle.ForeColor = dataGridView.DefaultCellStyle.ForeColor;
           }
         }
    }
    private void form_KeyUp(object sender, KeyEventArgs e){
      if(e.KeyCode == Keys.ControlKey){
         selectedRows = new DataGridViewRow[dataGridView.SelectedRows.Count];
         dataGridView.SelectedRows.CopyTo(selectedRows,0);
         foreach(DataGridViewRow row in selectedRows){
            row.DefaultCellStyle.BackColor = dataGridView.DefaultCellStyle.SelectionBackColor;
            row.DefaultCellStyle.ForeColor = dataGridView.DefaultCellStyle.SelectionForeColor;
         }
      }
    }
