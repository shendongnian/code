       public static DataTable ToDataTable<T>(IEnumerable<T> values)
        {
            DataTable table = new DataTable();
            foreach (T value in values)
            {
                if (table.Columns.Count == 0)
                {
                    foreach (var p in value.GetType().GetProperties())
                    {
                        table.Columns.Add(p.Name);
                    }
                }
                DataRow dr = table.NewRow();
                foreach (var p in value.GetType().GetProperties())
                {
                    dr[p.Name] = p.GetValue(value, null) + "";
                }
                table.Rows.Add(dr);
            }
            return table;
        }
