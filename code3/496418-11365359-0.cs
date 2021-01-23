    DataSet grid = new DataSet();
                DataTable table = grid.Tables[0];
    
                List<string> tableData = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        tableData.Add(row[i].ToString());
                    }
                }
    
                tableData.Where(x => x == "TestValue");
