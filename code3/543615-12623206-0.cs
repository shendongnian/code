    private void dgvUsers_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
                if (e.ColumnIndex != 0)
                {
                    if ((e.RowIndex == dgvUsers.NewRowIndex) && (dgvUsers[0, e.RowIndex].Value == null))
                    {
                        e.Cancel = true;
                    }
                }
            }
