          public DataTable  CreateDataTable(Dictionary<string,Type> columns)
          {
                DataTable dt = new DataTable();
                foreach( var key in columns)
                {
    		        var column = dt.Columns.Add();
                    column.ColumnName = key.Key;
                    column.DataType = key.Value;
                }
                return dt;
    
            }
    
    
            public void CreateNewDataTable()
            {
                var columns = new Dictionary<string, Type>()
                    {
                        {"column", typeof (string)}
                    };
                var dt = CreateDataTable(columns);
            }
