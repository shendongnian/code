        private DataTable MergeDataTables(List<DataTable> tables)
        {
            //.
            if (null == tables || false == tables.Any())
            {
                return null;
            }
            //.
            DataTable merged = tables.First();
            //.
            for (int i = 1; i < tables.Count; i++)
            {
                var cur = tables[i];
                //.merge columns
                foreach (DataColumn c in cur.Columns)
                {
                    if (-1 == merged.Columns.IndexOf(c.ColumnName))
                    {
                        merged.Columns.Add(c.ColumnName, c.DataType);
                    }
                }
                //.merge rows
                foreach (DataRow r in cur.Rows)
                {
                    merged.ImportRow(r);
                }
            }
            //.
            return merged;
        }
