            int currentcolumnclicked = e.ColumnIndex;
            for (int i = 0; i <= dgvlist.Columns.Count - 1; i++)
            {
                if (dgvlist.Columns[i] is DataGridViewCheckBoxColumn)
                {
                    if (Convert.ToString(dgvlist.CurrentRow.Cells[i].EditedFormattedValue) == "True" && i !=currentcolumnclicked)
                    {
                        dgvlist.CurrentRow.Cells[i].Value = false;
                    }
                }
            }
        }
