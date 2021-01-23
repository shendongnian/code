    private void server_SelectedIndexChanged(object sender, EventArgs e)
    {
        servername = server.SelectedValue.ToString();
        constring = "server=servername;Integrated Security = sspi";
        using (var con = new SqlConnection(constring))
        using (var da = new SqlDataAdapter("SELECT Name FROM master.sys.databases", con))
        {
            var ds = new DataSet();
            da.Fill(ds);
            databases.DataSource = ds.Tables[0].Rows.Select(x => x["Name"].ToString());
            //...
        }
    }
