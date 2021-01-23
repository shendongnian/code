        private void getMenu()
    {
       // Menu menuBar = new Menu();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "server=(local);database=PhilipsMaterials;Integrated Security=SSPI;";
        con.Open();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string sql = "Select [Material Name] from Materials";
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        da.Fill(ds);
        dt = ds.Tables[0];
        DataRow[] drowpar = dt.Select();
        String s = "sss";
        foreach (DataRow dr in drowpar)
        {
            menuBar.Items.Add(new MenuItem(dr["Material Name"].ToString()));
        }
    
        con.Close();
    
    }
    }
