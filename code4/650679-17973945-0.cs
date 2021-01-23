     private void timer1_tick(object sender,EventArgs e)
        {
        if(CheckDatabaseState() == "ONLINE")
           MessageBox.Show("db is online");
        else
        MessageBox.Show("db is NOT online");
        }
        
        Public string CheckDatabaseState()
        {
            string Constr = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Initial Catalog=master;";
        
             string sql = string.Format("SELECT Name, state_desc FROM sys.databases where name = '{0}'", dbName);     
        
                    SqlConnection conn;
                    SqlCommand comm;
                    SqlDataAdapter adapter;
                    DataSet ds = new DataSet();
        
                    conn = new SqlConnection(Constr);
                    comm = new SqlCommand(sql, conn);
                    adapter = new SqlDataAdapter(comm);
                    adapter.Fill(ds);
        
                    return ds.Tables[0]["state_desc"].ToString();
        }
