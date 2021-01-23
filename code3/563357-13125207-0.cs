        private void dgvRMADetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRMADetail.CurrentCell is DataGridViewCheckBoxCell))
            {
                dgvRMADetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void dgvRMADetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == useRowCheckboxColumn.Index)
            {
               // Logic for doing whatever when the checkbox is checked.
            }
        }
