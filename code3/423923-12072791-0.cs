    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridViewComboBoxCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (cell.DataSource == null)
                {
                    cell.DataSource = this._ComboItemsBindingSource;
                    cell.DisplayMember = "Value"; //lite-weight wrapper on string
                    cell.ValueMember = "Value";   //where Value is a property
                }
            }
        }
