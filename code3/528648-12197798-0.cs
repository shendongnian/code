            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            ds.Tables.Add("table0");
            DataColumn dc = new DataColumn("browser");
            ds.Tables[0].Columns.Add(dc);
            ds.Tables[0].Rows.Add("12356.56@Firefox1@23423");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
                string str = ds.Tables[0].Rows[i][0].ToString();
                if((str.ToLower().CompareTo("firefox"))!=0)
                {
                    ds.Tables[0].Rows[i][0] = "firefox";
                }
            }
            _gridView.DataSource = ds;
            _gridView.DataBind();
         
