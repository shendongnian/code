     DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();
    // you can get that using the instanceName property 
    string instancename = table.Rows[0].Columns["InstanceName"].ToString();
     //and version property tells u the version of sql server i.e 2000, 2005, 2008 r2 etc
    string sqlversion = table.Rows[0].Columns["Version"].ToString();
