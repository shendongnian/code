    var table = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
    foreach (var server in table.Rows)
    {
      ddlPublisherServer.Items.Add(server[table.Columns["ServerName"]]);
    }
