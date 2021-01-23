        private DataGridView DGV_Creation(DataGridView dgv, int columns, int rows)
        {
            for (int i = 1; i <= columns; i++)
            {
                dgv.Columns.Add("col" + i, "column " + i);
            }
            for (int j = 0; j < rows; j++)
            {
                dgv.Rows.Add();
            }
            return dgv;
        }
