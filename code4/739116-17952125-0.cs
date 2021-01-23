    // A list of the check box cell so we can use LINQ to access them
    private List<DataGridViewCheckBoxCell> checkBoxCellList = new List<DataGridViewCheckBoxCell>();
    private DataGridView dgv = new DataGridView();
    private void dataGridViewBuild() {
        DataGridViewCheckBoxColumn cbcolumn = new DataGridViewCheckBoxColumn(false);
        cbcolumn.Name = "Selected";
        cbcolumn.HeaderText = cbcolumn.Name;            
        this.dgv.Columns.Add(cbcolumn);
        // Add 100 rows
        for (int i = 0; i < 100; i++) {
            dgv.Rows.Add();
        }
        // Get all of the checkbox cells and add them to the list
        foreach (DataGridViewRow row in this.dgv.Rows) {                
            this.checkBoxCellList.Add((DataGridViewCheckBoxCell)row.Cells["Selected"]);
        }            
        // Subscribe to the value changed event for the datagridview
        this.dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged);            
        this.Controls.Add(this.dgv);
    }
    void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        // Get the cell checkbox cell for the row that was changed
        DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)this.dgv[e.ColumnIndex, e.RowIndex];
        // If the value is true then set all other checkboxcell values to false with LINQ
        if (checkBoxCell.Value != null && Convert.ToBoolean(checkBoxCell.Value)) {
            this.checkBoxCellList.FindAll(cb => Convert.ToBoolean(cb.Value) == true && cb != checkBoxCell).ForEach(cb => cb.Value = false);
        }
     
        // If the checkboxcell was made false and no other is true then reset the value to true       
        if (this.checkBoxCellList.FindAll(cb => Convert.ToBoolean(cb.Value) == true).Count == 0) {
                checkBoxCell.Value = true;
        }
    }
