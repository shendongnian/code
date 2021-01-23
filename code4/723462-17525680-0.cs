    var dt = new DataTable();
    dt.Columns.Add("Id");
    dt.Columns.Add("Value1");
    dt.Columns.Add("Value2");
    dt.Rows.Add(1, "aa", "xx");
    dt.Rows.Add(2, "bb","yy");
    dt.Rows.Add(3, "cc", "zz");
    tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
    tableLayoutPanel1.ColumnCount = 4;
    tableLayoutPanel1.AutoSize = true;
    for (int i = 0; i < dt.Columns.Count; i++)
    {
        var l = new Label();
        l.Dock = DockStyle.Fill;
        l.Text = dt.Columns[i].ColumnName;
        tableLayoutPanel1.Controls.Add(l, i, 0);
    }
    var emptyLabel = new Label();
    emptyLabel.Text = "Empty label";
    tableLayoutPanel1.Controls.Add(emptyLabel, 4, 0);
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
        {
            var tb = new TextBox();
            tb.Multiline = true;
            tb.Dock = DockStyle.Fill;
            tb.Text = dt.Rows[i][j].ToString();
            tableLayoutPanel1.Controls.Add(tb, j, i+1);
            if (i == 1 && j == 2)
                tableLayoutPanel1.SetColumnSpan(tb, 2);
        }
    }
