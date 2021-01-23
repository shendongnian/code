        private void dataGridViewCrossRef_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 25)
            {
                bool IsBool = false;
                if (bool.TryParse(dataGridViewCrossRef[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), out IsBool))
                {
                   //Some code
                }
            }
        }
