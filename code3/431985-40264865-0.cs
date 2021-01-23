    bool notlastColumn = true;
    protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg,System.Windows.Forms.Keys keyData)
    {
    int icolumn = dataGridView1.CurrentCell.ColumnIndex;
    int irow = dataGridView1.CurrentCell.RowIndex;
    int i = irow;
    if (keyData == Keys.Enter)
    {
        if (icolumn == dataGridView1.Columns.Count - 1)
        {
             //dataGridView1.Rows.Add();
            if (notlastColumn == true)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
            }
            dataGridView1.CurrentCell = dataGridView1[0, irow + 1];
         }
        else
        {
            // to pass hidden cell, because will fire exception
            //exception: Current cell cannot be set to an invisible cell
            // the do while loop will enable you to pass any hidden cell
             do
              {
                icolumn++;
              } while (!dgv[icolumn, irow].Visible);
            dataGridView1.CurrentCell = dataGridView1[icolumn, irow];
        }
        return true;
    }
    else
        if (keyData == Keys.Escape)
        {
            this.Close();
            return true;
        }
    //below is for escape key return
    return base.ProcessCmdKey(ref msg, keyData);
     
}
