    DataTable matrix = ... // get matrix values from db
    DataTable newDataTable = new DataTable();
    newDataTable.Columns.Add("c_to", typeof(string));
    newDataTable.Columns.Add("p_to", typeof(string));
    var query = from r in matrix.AsEnumerable()
                where r.Field<string>("c_to") == "foo" &&
                        r.Field<string>("p_to") == "bar"
                let objectArray = new object[]
                {
                    r.Field<string>("c_to"), r.Field<string>("p_to")
                }
                select objectArray;
    foreach (var array in query)
    {
        newDataTable.Rows.Add(array);
    }
