        public DataTable MergeTables(DataTable dtFirst, DataTable dtSecond, string CommonColumn)
        {
            DataTable dtResults = dtFirst.Clone();
            int count = 0;
            for (int i = 0; i < dtSecond.Columns.Count; i++)
            {
                if (!dtFirst.Columns.Contains(dtSecond.Columns[i].ColumnName))
                {
                    dtResults.Columns.Add(dtSecond.Columns[i].ColumnName, dtSecond.Columns[i].DataType);
                    count++;
                }
            }
            DataColumn[] columns = new DataColumn[count];
            int j = 0;
            for (int i = 0; i < dtSecond.Columns.Count; i++)
            {
                if (!dtFirst.Columns.Contains(dtSecond.Columns[i].ColumnName))
                {
                    columns[j++] = new DataColumn(dtSecond.Columns[i].ColumnName, dtSecond.Columns[i].DataType);
                }
            }
            dtResults.BeginLoadData();
            foreach (DataRow dr in dtFirst.Rows)
            {
                dtResults.Rows.Add(dr.ItemArray);
            }
            foreach (DataRow dr in dtSecond.Rows)
            {
                foreach (DataRow dr1 in dtResults.Rows)
                {
                    if (dr1[CommonColumn].ToString().Equals(dr[CommonColumn].ToString()))
                    {
                        foreach (DataColumn c in columns)
                        {
                            dr1[c.ColumnName] = dr[c.ColumnName];
                        }
                    }
                }
            }
            dtResults.EndLoadData();
            return dtResults;
        }
