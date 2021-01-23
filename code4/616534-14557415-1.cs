        private void dataGridViewCrossRef_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 25)
            {
                dataGridViewCrossRef[e.ColumnIndex, e.RowIndex].Value = !(bool)dataGridViewCrossRef[e.ColumnIndex, e.RowIndex].Value;
                if ((bool)dataGridViewCrossRef[e.ColumnIndex, e.RowIndex].Value)
                {
                    //Some code
                }
            }
        }
