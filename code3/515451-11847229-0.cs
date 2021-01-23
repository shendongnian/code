    public DataGridViewRow FindRow(DataGridView dgv, DateTime searchID)
        {
            DataGridViewRow row = dgv.Rows
                .Cast<DataGridViewRow>()
                .Where(r => ((DateTime)r.Cells["DateAdded"].Value <= searchID))
                .Last();
            return row;
        }
