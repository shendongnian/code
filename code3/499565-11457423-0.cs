    public Form1()
    {
        InitializeComponent();
        // So this is the first time we call your refresh grid with some default string query
        RefreshDataGrid(query);
 
        // Now one time only we call SetUpDataGridView()
        SetUpDataGridView();
        // Now once we have done that we set AutoGenerateColumns to false
        dataGridView1.AutoGenerateColumns = false;
    }
    public void RefreshDataGrid(string query)
    {
        Buisness_logic bl = new Buisness_logic();
        dataGridView1.DataSource = bl.GetDataTable(query);
        // We no longer need to call SetUpDataGridView()
        // SetUpDataGridView();
        dataGridView1.ClearSelection();
    }
