    bindingSource1.DataSource = tbData;
    dataGridView1.DataSource = bindingSource1;
    bindingSource1.ListChanged += new ListChangedEventHandler(bindingSource1_ListChanged); 
    public void bindingSource1_ListChanged(object sender, ListChangedEventArgs e)
    {
        DataGridViewCellStyle cellStyle = new DataGridViewCellStyle(); 
        cellStyle.ForeColor = Color.Red;
        dataGridView1.Rows[e.NewIndex].Cells[e.PropertyDescriptor.Name].Style = cellStyle;
    }
