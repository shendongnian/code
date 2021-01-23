    var stringBuilder = new SqlConnectionStringBuilder();
    var sqlCommand = "select TOP 100 * from MyTable;";
    stringBuilder.IntegratedSecurity = true;
    stringBuilder.InitialCatalog = "MyCatalog";
    stringBuilder.DataSource = @"myServer\InstanceName,1433";
    // This will give the connection string:
    // "Data Source=myServer\\InstanceName,1433;Initial Catalog=MyCatalog;Integrated Security=True"
    using (var connection = new SqlConnection(stringBuilder.ToString()))
    using (var command = new SqlCommand(sqlCommand, connection))
    using (var adapter = new SqlDataAdapter(command))
    {
        var table = new DataTable();
        connection.Open();
        adapter.Fill(table);
    }
