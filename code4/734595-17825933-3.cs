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
