    private void DynList_RowValidated(object sender, DataGridViewCellEventArgs e)
    {
    	if (ChangedRow == true) {
    		ChangedRow = false;
    		//Row Changed...
    	}
    
    }
    bool ChangedRow;
    private void DynList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
    	ChangedRow = true;
    }
