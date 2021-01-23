    //I got the kind of Index not valid or other index errors
    //RowValidating is fired when entering the row and when leaving it
    //In my case there was no point in validating on row enter
    private void dgvTest_RowValidating(object sender, DataGridViewCellCancelEventArgs e)    {
    if (Disposing)
         return;
    if (!dgvTest.IsCurrentRowDirty) {
         return;
    	}
    try {
    var v = dgvTest.Rows[e.RowIndex].DataBoundItem;
    } catch {
    return;
    }
}
    //I had to trap some errors and change things accordingly
    private void dgvTest_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            if (e.Exception.Message.Contains("Index") && e.Exception.Message.Contains("does not have a value")) {
                //when editing a new row, after first one it throws an error
                //cancel everything and reset to allow the user to make the desired changes
                bindingSource.CancelEdit();
                bindingSource.EndEdit();
                bindingSource.AllowNew = false;
                bindingSource.AllowNew = true;
                e.Cancel = true;
                dgvTest.Visible = false;
                dgvTest.Visible = true;
            }
        }
 
     //Some problemes occured when entering a new row
     //This resets the bindingsource's AllowNew property so the user may input new data
     private void dgvTest_RowEnter(object sender, DataGridViewCellEventArgs e) {
                if (!_loaded)
                    return;
                if (e.RowIndex == dgvTest.NewRowIndex)
                    if (String.IsNullOrWhiteSpace(dgvTest.Rows[e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Cells[_idColumn].Value.ToStringSafe())) {
                        bindingSource.CancelEdit();
                        bindingSource.AllowNew = false;
                        bindingSource.AllowNew = true;
                    }
            }
