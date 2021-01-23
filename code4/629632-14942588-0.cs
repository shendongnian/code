        public string origData { get; set; }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
                origData = dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim(); //Get the original data
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                if (e.ColumnIndex == 1)
                {
                    if (origData != dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString().Trim()) //If not equal to original data will trigger
                    {
                        //Do stuff
                    }
                }
            }
        }
