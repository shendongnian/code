    DataTable dt = populatedd();
       statusList.DataSource = dt;
       statusList.DataTextField = "name";
       statusList.DataValueField = "id";
       statusList.DataBind();
    
        public DataTable populatedd()
        {
            string myQuery = "select id,name from yourtable order by name";
            SqlDataAdapter dap = new SqlDataAdapter(myQuery, con);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            return ds.Tables[0];
        }
