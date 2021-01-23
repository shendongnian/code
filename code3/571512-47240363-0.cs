    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView.Columns["Select"].Index)
            {
                dataGridView.EndEdit();
                if ((bool)dataGridView.Rows[e.RowIndex].Cells["Select"].Value)
                {
                    //-- checking current select, needs to uncheck any other cells that are checked
                    foreach(DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Index == e.RowIndex)
                        {
                            dataGridView.Rows[row.Index].SetValues(true);
                        }
                        else
                        {
                            dataGridView.Rows[row.Index].SetValues(false);
                        }
                    }
                }
            }
        }
