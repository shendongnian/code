    private void DataGridView1_CellFormatting(object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        if (dgv.Columns[e.ColumnIndex].Name == "i" &&
            e.RowIndex >= 0 &&
            dgv["i", e.RowIndex].Value is int) &&
            (((int)dgv["i", e.RowIndex].Value) == 0)
            {
               e.Value = "-";
               e.FormattingApplied = true;           
            }
        }
        else if (dgv.Columns[e.ColumnIndex].Name == "b" &&
            e.RowIndex >= 0 &&
            dgv["b", e.RowIndex].Value is int) &&
            (((int)dgv["b", e.RowIndex].Value) == 1000)
            {
               e.Value = "Good";
               e.FormattingApplied = true;           
            }
        }
    }
