        private void tbljobdata_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            else
                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
