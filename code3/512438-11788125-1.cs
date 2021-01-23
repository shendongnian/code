    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        var condition = false;
        for (int i = 0; i < 4; i++) table.Columns.Add();
        AddArray(table, new string[4] { "AAA", "aaa", "AAA", "aaa" });
        AddArray(table, new string[4] { "BBB", "bbb", "BBB", "bbb" });
        if (condition)
        {
            AddArray(table, new string[4] { "CCC", "ccc", "CCC", "ccc" });
            AddArray(table, new string[4] { "DDD", "ddd", "DDD", "ddd" });
        }
        else
        {
            AddArray(table, new string[4] { "CCC", "ccc", "XXX", "xxx" });
            AddArray(table, new string[4] { "DDD", "ddd", "YYY", "yyy" });
            AddArray(table, new string[4] { "", "", "CCC", "ccc" });
            AddArray(table, new string[4] { "", "", "DDD", "ddd" });
        }
        ExampleGridView.DataSource = table;
        ExampleGridView.DataBind();
    }
    private void AddArray(DataTable table, string[] items) {
        var row = table.NewRow();
        row.ItemArray = items;
        table.Rows.Add(row);
    }
