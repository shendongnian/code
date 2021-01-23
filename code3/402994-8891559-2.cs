    private void SortDataByMultiColumns()
    {
        DataView view = ds.Tables[0].DefaultView;
        view.Sort = "day ASC, status DESC"; 
        dataGridView1.DataSource = view; //rebind the data source
    }
