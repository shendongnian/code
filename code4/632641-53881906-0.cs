    Try This ...
        public DataTable getDiffRecords(DataTable dtDataOne, DataTable dtDataTwo)
        {
            DataTable returnTable = new DataTable("returnTable");
            using (DataSet ds = new DataSet())
            {
                ds.Tables.AddRange(new DataTable[] { dtDataOne.Copy(), dtDataTwo.Copy() });
                DataColumn[] firstColumns = new DataColumn[ds.Tables[0].Columns.Count];
                for (int i = 0; i < firstColumns.Length; i++)
                {
                    firstColumns[i] = ds.Tables[0].Columns[i];
                }
                DataColumn[] secondColumns = new DataColumn[ds.Tables[1].Columns.Count];
                for (int i = 0; i < secondColumns.Length; i++)
                {
                    secondColumns[i] = ds.Tables[1].Columns[i];
                }
                DataRelation r1 = new DataRelation(string.Empty, firstColumns, secondColumns, false);
                ds.Relations.Add(r1);
                DataRelation r2 = new DataRelation(string.Empty, secondColumns, firstColumns, false);
                ds.Relations.Add(r2);
                for (int i = 0; i < dtDataOne.Columns.Count; i++)
                {
                    returnTable.Columns.Add(dtDataOne.Columns[i].ColumnName, dtDataOne.Columns[i].DataType);
                }
                returnTable.BeginLoadData();
                foreach (DataRow parentrow in ds.Tables[0].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r1);
                    if (childrows == null || childrows.Length == 0)
                        returnTable.LoadDataRow(parentrow.ItemArray, true);
                }
                foreach (DataRow parentrow in ds.Tables[1].Rows)
                {
                    DataRow[] childrows = parentrow.GetChildRows(r2);
                    if (childrows == null || childrows.Length == 0)
                        returnTable.LoadDataRow(parentrow.ItemArray, true);
                }
                returnTable.EndLoadData();
            }
            return returnTable;
        }
