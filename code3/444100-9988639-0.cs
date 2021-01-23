    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)//The index of your Quantity Column
            {
                int qty = (int)DT.Rows[e.RowIndex][e.ColumnIndex];
                if (qty > 0)//Your logic if required
                {
                    DT.Rows.Add(DT.NewRow());                    
                }
            }
        }
