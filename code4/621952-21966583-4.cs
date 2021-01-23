    protected void Page_Load(object sender, EventArgs e)
            {
                FillDynamicTable();
    
                if (!IsPostBack)
                {
    
                }
    
            }
        private void FillDynamicTable()
        {
            Table1.Rows.Clear(); //  Count=0 but anyways
            if (Session["Table1"] == null) return;
            foreach (var data in Session["Table1"] as List<MyObject>)
            {
                AddRow(data);
            }
        }
        private void AddRow(MyObject data)
        {
            var row = new TableRow { Height = 50 };
            var cell = new TableCell();
            var label = new Label { Text = data.something, Width = 150 };
            cell.Controls.Add(label);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }
     
