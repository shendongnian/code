     <DataGrid Name="grid" AutoGenerateColumns="True" ItemsSource="{Binding}" />     
     public DataTable TableData {
            get {
                DataTable dt = new DataTable();
                dt.Columns.Add("col1");
                dt.Columns.Add("col2");
                dt.Rows.Add(new string[] {"val1", "val2"});
                return dt;
            }
        }
     grid.DataContext = TableData;
