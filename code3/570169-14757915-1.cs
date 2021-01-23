    var dt = (from data in l_ds.Tables[0].AsEnumerable()
                      select data).ToList();
       foreach (DataColumn column in l_dt.Columns)
       {
          var binding = new Binding(string.Format("[{0}]", column.Ordinal));
          datagrid.Columns.Add(new DataGridTextColumn() 
                         { Header = column.ColumnName, Binding = binding });
       }
            datagrid.ItemsSource = dt;
