    DataTable table = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
    foreach (DataRow server in table.Rows)
    {
      ddlPublisherServer.Items.Add(server[table.Columns["ServerName"]].ToString());
    }
