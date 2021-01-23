    var nameGroups = from row in table1.AsEnumerable()
                     group row by new
                     {
                         Name = row.Field<string>("Name").ToLower(),
                         LastName = row.Field<string>("Lastname").ToLower(),
                     } into NameGroups
                     select NameGroups;
    var tblOut = new DataTable();
    tblOut.Columns.Add("Name");
    tblOut.Columns.Add("LastName");
    var distinctIDs = table1.AsEnumerable()
                            .Select(r => r.Field<string>("ID"))
                            .Distinct();
    foreach (var id in distinctIDs)
        tblOut.Columns.Add(id);
    foreach (var grp in nameGroups)
    {
        var row = tblOut.Rows.Add();
        row.SetField<string>("Name", grp.Key.Name);
        row.SetField<string>("LastName", grp.Key.LastName);
        foreach (DataColumn idCol in tblOut.Columns.Cast<DataColumn>().Skip(2))
        {
            bool userHasID = grp.Any(r => r.Field<string>("ID") == idCol.ColumnName);
            row.SetField<string>(idCol, userHasID ? "x" : "");
        }
    }
