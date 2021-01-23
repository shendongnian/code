           private DataGridViewCell _celWasEndEdit;
            private void datagridview_SelectionChanged(object sender, EventArgs e)
        {
            if (MouseButtons != 0) return;
            if (_celWasEndEdit != null && datagridview.CurrentCell != null)
            {
                // if we are currently in the next line of last edit cell
                if (datagridview.CurrentCell.RowIndex == _celWasEndEdit.RowIndex + 1 &&
                    datagridview.CurrentCell.ColumnIndex == _celWasEndEdit.ColumnIndex)
                {
                    int iColNew;
                    int iRowNew = 0;
                    if (_celWasEndEdit.ColumnIndex >= datagridview.ColumnCount - 1)
                    {
                        iColNew = 0;
                        iRowNew = dgvItems.CurrentCell.RowIndex;                   
                    }
                    else
                    {
                            iColNew = _celWasEndEdit.ColumnIndex + 1;
                            iRowNew = _celWasEndEdit.RowIndex;
                    datagridview.CurrentCell = datagridview[iColNew, iRowNew];
                }
            }
            _celWasEndEdit = null;
          }
        private void datagridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _celWasEndEdit = dgvItems[e.ColumnIndex, e.RowIndex];
        }
