    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    {
            int icolumn = dataGridView1.CurrentCell.ColumnIndex;
            int irow = dataGridView1.CurrentCell.RowIndex;
            if (keyData == Keys.Enter)
            {                                
                if (icolumn == dataGridView1.Columns.Count - 1)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1[0, irow + 1];
                }
                else
                {
                    dataGridView1.CurrentCell = dataGridView1[icolumn + 1, irow];
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
