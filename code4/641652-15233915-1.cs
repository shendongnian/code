    private static DataTable BuildDataTable(XElement x)
            {
                DataTable dt = new DataTable();
    
                dt.Columns.Add(new DataColumn(x.Name.ToString()));
                foreach (var d in x.Descendants())
                {
                    DataRow drow = dt.NewRow();
                    drow[0] = d.Value;
                    dt.Rows.Add(drow);
                }
                
                return dt;
            }
