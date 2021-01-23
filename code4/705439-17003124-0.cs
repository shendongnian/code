    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
    {
        if (keyData == Keys.Enter && this.dataGridView1.IsCurrentCellInEditMode && this.dataGridView1.CurrentCell.ColumnIndex==this.dataGridView1.Columns.Count-1)
        {
            SendKeys.Send("{DOWN}");
            return true;
        }
        else
            return base.ProcessCmdKey(ref msg, keyData);
    
    }
