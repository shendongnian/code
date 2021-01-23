    //convert datatable to list using LINQ. Input datatable is "dt", returning list of "name:value" tuples
    var lst = dt.AsEnumerable()
        .Select(r => r.Table.Columns.Cast<DataColumn>()
                .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
               ).ToDictionary(z=>z.Key,z=>z.Value)
        ).ToList();
    //now serialize it
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    return serializer.Serialize(lst);
