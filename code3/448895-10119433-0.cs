    DataTable table = new DataTable();
                
    table.Columns.Add("OrderCount",typeof(int));
                
    table.Columns.Add("OrderPrice",typeof(int));
                
    table.Rows.Add(new object[] { 1, 1 });
                
    table.Rows.Add(new object[] { 2, 3 });
                
    table.Rows.Add(new object[] { 4, 5 });
                
    table.Columns.Add("Result", typeof(string));
                
    table.Columns["Result"].Expression = "Convert(OrderCount, 'System.String') + OrderPrice";
