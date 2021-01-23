        private void dataGridViewCrossRef_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 25)
            {
                bool isChecked1 = false;
                isChecked1 = !(bool)dataGridViewCrossRef[25, e.RowIndex].Value;
                if (isChecked1)
                {
                    //Some code
                }
            }
        }
