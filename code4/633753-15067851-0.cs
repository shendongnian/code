    var dataTable = new DataTable();
    dataTable.Columns.Add(new DataColumn("Value", typeof(string)));
    for (int i = 0; i < hostnames.Length; i++)
    {
        var dr = dataTable.NewRow();
        dr[0] = "";
        dataTable.Rows.Add(dr);
    }
    using (var connection = new SqlConnection("connectionString"))
    using (var command = new SqlCommand("SELECT * FROM Table WHERE HostName IN (SELECT Value FROM @StringList)", connection))
    {
        SqlParameter stringListParameter = new SqlParameter("@StringList", SqlDbType.Structured);
        stringListParameter.Value = dataTable;
        stringListParameter.TypeName = "dbo.StringList";
        command.Parameters.Add(stringListParameter);
                
        // OPEN CONNECTION EXECUTE COMMAND ETC
                
    }
