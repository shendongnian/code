        private void tbljobdata_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
                tbljobdata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            else
                tbljobdata.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }
