    table1.Merge(table2, true, MissingSchemaAction.Add);
    finalTable = table1.Clone();
    finalTable.PrimaryKey = new DataColumn[] { finalTable.Columns["ID"], finalTable.Columns["Name"] };
    List<string> columnNames = new List<string>();
    for (int colIndex = 2; colIndex < finalTable.Columns.Count; colIndex++)
    {
    columnNames.Add(finalTable.Columns[colIndex].ColumnName);
    }
    foreach (string cols in columnNames)
    {
    var temTable = new DataTable();
    temTable.Columns.Add("ID", typeof(int));
    temTable.Columns.Add("Name", typeof(string));
    temTable.Columns.Add(cols, typeof(decimal));
    
    (from row in table1.AsEnumerable()
    group row by new { ID = row.Field<int>("ID"), Team = row.Field<string>("Team") } into grp
    orderby grp.Key.ID
    select new
    {
    ID = grp.Key.ID,
    Name = grp.Key.Team,
    cols = grp.Sum(r =>  r.Field<decimal?>(cols)),
    })
    .Aggregate(temTable, (dt, r) => { dt.Rows.Add(r.ID, r.Team, r.cols); return dt; });
    
    finalTable.Merge(temTable, false, MissingSchemaAction.Ignore);
    }
