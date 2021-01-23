        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Manually raise the CellValueChanged event
            // by calling the CommitEdit method.
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        public void dataGridView1_CellValueChanged(object sender,
                                                   DataGridViewCellEventArgs e)
        {
            // If a check box cell is clicked, this event handler sets the value
            // of a few other checkboxes in the same row as the clicked cell.
            if (e.RowIndex < 0) return; // row is sometimes negative?
            int ix = e.ColumnIndex;
            if (ix>=1 && ix<=3)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                DataGridViewCheckBoxCell checkCell =
                    (DataGridViewCheckBoxCell) row.Cells[ix];
                bool isChecked = (Boolean)checkCell.Value;
                if (isChecked)
                {
                    // Only turn off other checkboxes if this one is ON. 
                    // It's ok for all of them to be OFF simultaneously.
                    for (int i=1; i <= 3; i++)
                    {
                        if (i != ix)
                        {
                            ((DataGridViewCheckBoxCell) row.Cells[i]).Value = false;
                        }
                    }
                }
                dataGridView1.Invalidate();
            }
        }
