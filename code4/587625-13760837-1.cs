    protected void Page_Load(object sender, EventArgs e)
        {   
            gvTest.DataSource = GetData();
            gvTest.DataBind();
        }
    
        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FruitID"));
            for (int i = 0; i < 3; i++)
            {
                DataRow dr=dt.NewRow();
                dr["FruitID"] = i + 1;
                dt.Rows.Add(dr);
            }
            return dt;
        }
