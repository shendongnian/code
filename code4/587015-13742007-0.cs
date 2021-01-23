    using (var con = new System.Data.SqlClient.SqlConnection(conStr))
    {
        con.Open();
        DataTable schemaTable = con.GetSchema("Tables");
        IList<string> allTableNames = schemaTable.AsEnumerable()
            .Where(r => r.Field<string>("TABLE_TYPE") == "BASE TABLE")
            .Select(r => r.Field<string>("TABLE_NAME"))
            .ToList();
    }
