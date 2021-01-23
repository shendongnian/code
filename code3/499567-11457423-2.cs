    public void RefreshDataGrid(string query)
    {
        Buisness_logic bl = new Buisness_logic();
        // This is the new line
        dataGridView1.DataSource = typeof(List<>);
        dataGridView1.DataSource = bl.GetDataTable(query);
        // We no longer need to call SetUpDataGridView()
        // SetUpDataGridView();
        dataGridView1.ClearSelection();
    }
