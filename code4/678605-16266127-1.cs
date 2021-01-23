    // this is sample C# console application 
    using System.Data;
    using System.Linq; 
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = GetTable();
                // get list of Data Table column names like A, B, C, D...
                var columnNames = (from DataColumn col in dt.Columns
                                   select col.ColumnName).ToList();
                // compute sum for each column and get list of objects which having sum and column name as property. 
                var computed = columnNames.Select(c => new { ColumnName = c, Sum = dt.Compute(string.Format("Sum({0})", c), "") }).OrderByDescending(p => p.Sum).ToList();
    
                // set the column position based on Sum of the column 
                for (int i = 0; i < computed.Count(); i++)
                {
                    dt.Columns[computed[i].ColumnName].SetOrdinal(i);
                }
    
            }
            // testing I have added this method to create Data Table with testing data
            static DataTable GetTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("A", typeof(int));
                table.Columns.Add("B", typeof(int));
                table.Columns.Add("C", typeof(int));
                table.Columns.Add("D", typeof(int));
    
                table.Rows.Add(1, 0, 0, 1);
                table.Rows.Add(0, 0, 0, 1);
                table.Rows.Add(1, 1, 0, 1);
    
                return table;
            }
        }
    }
