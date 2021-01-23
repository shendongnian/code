    private DataGridView dataGridView1 = new DataGridView();
    private BindingSource bindingSource1 = new BindingSource();
    private void Form1_Load(object sender, System.EventArgs e)
    {
        // Bind the DataGridView to the BindingSource        
        dataGridView1.DataSource = bindingSource1;
        SortDataByMultiColumns(); //Sort the Data
    }
    private void SortDataByMultiColumns()
    {
        DataView view = dataTable1.DefaultView;
        view.Sort = "day ASC, status DESC"; 
        bindingSource1.DataSource = view; //rebind the data source
    }
