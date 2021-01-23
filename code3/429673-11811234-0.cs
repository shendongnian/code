        dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
