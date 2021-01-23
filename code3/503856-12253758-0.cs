        if (e.ColumnIndex > 9 && e.RowIndex >= 0)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[0].Value is DBNull)
            {
                //do nothing
            }
            else
            {
                this.Validate();
            }
        }
