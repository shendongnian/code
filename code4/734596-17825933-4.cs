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
