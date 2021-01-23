    private void dataGridViewMain_CellValueNeeded(Object sender, DataGridViewCellValueEventArgs e)
        {
            if (this.Cache != null)
            {
                e.Value = this.Cache.GetCellValue(e.RowIndex, e.ColumnIndex);
            }
        }
