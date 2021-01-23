    foreach (DataGridViewRow row in myDataGridViewProducts.Rows) 
    {
            DataGridViewComboBoxCell cell =DataGridViewComboBoxCell)row.Cells("myProductCol");
        cell.DataSource = _Usercom.GetProgramName();
        cell.DataPropertyName = "ProgramName";        
        cell.DisplayMember = "Name";
        cell.ValueMember = "Self"; // key to getting the databinding to work
        // no need to set cell.Value anymore!
    }
