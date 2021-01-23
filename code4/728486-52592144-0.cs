    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if(e.ColumnIndex == 0)//Just care the first column
        this.BeginInvoke(new MethodInvoker(DoSortGrid));
    }
    private void DoSortGrid(){        
        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView.CurrentRow.Index;//Keep the current row in view for large list
    }
