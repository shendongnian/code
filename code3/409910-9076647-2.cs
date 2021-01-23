        public DataTable CompareDataTables(DataTable first, DataTable second)
        {
            first.TableName = "FirstTable";
            second.TableName = "SecondTable";
            DataTable table = new DataTable("Difference");
            try
            {
                using (DataSet ds = new DataSet())
                {
                    ds.Tables.AddRange(new DataTable[] { first.Copy(), second.Copy() });
                    DataColumn[] firstcolumns = new DataColumn[ds.Tables[0].Columns.Count];
                    for (int i = 0; i < firstcolumns.Length; i++)
                    {
                        firstcolumns[i] = ds.Tables[0].Columns[i];
                    }
                    DataColumn[] secondcolumns = new DataColumn[ds.Table[1].Columns.Count];
                    for (int i = 0; i < secondcolumns.Length; i++)
                    {
                        secondcolumns[i] = ds.Tables[1].Columns[i];
                    }
                    DataRelation r = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);
                    ds.Relations.Add(r);
                    for (int i = 0; i < first.Columns.Count; i++)
                    {
                        table.Columns.Add(first.Columns[i].ColumnName, first.Columns[i].DataType);
                    }
                    table.BeginLoadData();
                    foreach (DataRow parentrow in ds.Tables[0].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r);
                        if (childrows == null || childrows.Length == 0)
                            table.LoadDataRow(parentrow.ItemArray, true);
                    }
                    table.EndLoadData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return table;
        }
