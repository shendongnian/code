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
