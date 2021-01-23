    DataTable table = SqlDataSourceEnumerator.Instance.GetDataSources();
    foreach (DataRow server in table.Rows)
    {
        string servername = server[table.Columns["ServerName"]].ToString();
        
        // you can get that using the instanceName property 
        string instancename = server[table.Columns["InstanceName"].ToString();
    
        //and version property tells you the version of sql server i.e 2000, 2005, 2008 r2 etc
        string sqlversion = server[table.Columns["Version"].ToString();
    
        //to form the servername you can combine the server and instancenames as
        string sqlserverfullname = String.Format("{0}\{1}",servername, instancename);
    
        cmbshowallsqlserver.Items.Add(sqlserverfullname);
    }
