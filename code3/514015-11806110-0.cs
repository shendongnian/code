            dgv.AutoGenerateColumns = false;
            for (int i = 1; i <= columns; i++)
            {
                dgv.Columns.Add("col" + i, "column " + i);
                dgv.Columns[i - 1].FillWeight = 1;
            }
            for (int j = 0; j < rows; j++)
                dgv.Rows.Add();
