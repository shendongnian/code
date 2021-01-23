    public DataTable CompareDataTables(DataTable first, DataTable second)
    {
        first.TableName = "FirstTable";
        second.TableName = "SecondTable";
    
        //Create Empty Table
        DataTable table = new DataTable("Difference");
    
        try
        {
            //Must use a Dataset to make use of a DataRelation object
            using (DataSet ds = new DataSet())
            {
                //Add tables
                ds.Tables.AddRange(new DataTable[] { first.Copy(), second.Copy() });
    
                //Get Columns for DataRelation
                DataColumn[] firstcolumns = new DataColumn[ds.Tables[0].Columns.Count];
    
                for (int i = 0; i < firstcolumns.Length; i++)
                {
                    firstcolumns[i] = ds.Tables[0].Columns[i];
                }
    
                DataColumn[] secondcolumns = new DataColumn[ds.Tables[1].Columns.Count];
    
                for (int i = 0; i < secondcolumns.Length; i++)
                {
                    secondcolumns[i] = ds.Tables[1].Columns[i];
                }
    
                //Create DataRelation
                DataRelation r = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);
    
                ds.Relations.Add(r);
    
                //Create columns for return table
                for (int i = 0; i < first.Columns.Count; i++)
                {
                    table.Columns.Add(first.Columns[i].ColumnName, first.Columns[i].DataType);
                }
    
                //If First Row not in Second, Add to return table.
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
    }
