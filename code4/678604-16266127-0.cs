    using System.Data;
    using System.Linq;
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = GetTable();
    
                var columnNames = (from DataColumn col in dt.Columns
                                   select col.ColumnName).ToList();
    
                var computed = columnNames.Select(c => new { ColumnName = c, Sum = dt.Compute(string.Format("Sum({0})", c), "") }).OrderByDescending(p => p.Sum).ToList();
    
                for (int i = 0; i < computed.Count(); i++)
                {
                    dt.Columns[computed[i].ColumnName].SetOrdinal(i);
                }
    
            }
    
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
