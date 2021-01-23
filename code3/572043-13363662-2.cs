    private void server_SelectedIndexChanged(object sender, EventArgs e)
    {
        string serverName = server.SelectedValue.ToString();
        string connString = string.Format("server={0};Integrated Security = sspi", serverName);
        using (var con = new SqlConnection(connString))
        {
            using (var da = new SqlDataAdapter("SELECT Name FROM master.sys.databases", con))
            {
                var ds = new DataSet();
                da.Fill(ds);
                databases.DataSource = ds.Tables[0].Rows.Select(x => x["Name"].ToString());
                //...
            }
        }
    }
