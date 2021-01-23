            if ((sender as DataGridView).CurrentCell is DataGridViewCheckBoxCell)
            {
                foreach (DataGridViewRow row in dgvCaixa.Rows)
                {
                    if (row.Index != dgvCaixa.CurrentCell.RowIndex && Convert.ToBoolean(row.Cells[e.ColumnIndex].Value) == true)
                    {
                        row.Cells[e.ColumnIndex].Value = false;
                    }
                }
            }
        }
