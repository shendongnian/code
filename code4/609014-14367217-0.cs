     // EditingCOntrol Showing
    
        If(datagridview.CurrentCell.ColumnIndex == 1)
        {
            TextBox dgvEditBox = e.Control as TextBox;
            if (dgvEditBox != null)
            {
                dgvEditBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                dgvEditBox.AutoCompleteCustomSource = source;
                dgvEditBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
    
    
    // public Object 
    
     public AutoCompleteStringCollection source = new AutoCompleteStringCollection();
